using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Facepunch.Steamworks.Utility;
using SteamAPIValidator;

namespace Steamworks
{
	public static class SteamClient
	{

        /// <summary>
        /// Fires when an invalid Steam DLL has been detected. Return true if you wish to allow the DLL to still run, else return false.
        /// </summary>
        public static Func<bool> InvalidSteamDllHandler = () =>
        {
            Debug.WriteLine(
                "The current Steam API DLL appears to be a modified version. Automatically not trusting it. Report to FP immediately.");
            return true;
        };

		static bool initialized;

        public static bool AutoCallbackUpdate = false;

		public static void Init( uint appid, bool allowDevAppIdFallback = false)
		{
			if ( IntPtr.Size != 8 )
			{
				throw new System.Exception( "Only 64bit processes are currently supported" );
			}

			System.Environment.SetEnvironmentVariable( "SteamAppId", appid.ToString() );
			System.Environment.SetEnvironmentVariable( "SteamGameId", appid.ToString() );

            if (!SteamAPI.Init())
            {
                if (allowDevAppIdFallback && appid != 480)
                {
                    Init(480);
                    return;
                }
                throw new System.Exception("SteamApi_Init returned false. Steam isn't running, couldn't find Steam, AppId is unreleased, Don't own AppId.");    
            }

            if (PlatformUtility.CurrentPlatform == PlatformEnum.Windows && !SteamApiValidator.IsValidSteamApiDll() && !InvalidSteamDllHandler())
            {
                SteamAPI.Shutdown();
                throw new FilthyPirateException();
            }

            AppId = appid;
            initialized = true;
 
            SteamApps.InstallEvents();
            SteamUtils.InstallEvents();
            SteamParental.InstallEvents();
            SteamMusic.InstallEvents();
            SteamVideo.InstallEvents();
            SteamUser.InstallEvents();
            SteamFriends.InstallEvents();
            SteamScreenshots.InstallEvents();
            SteamUserStats.InstallEvents();
            SteamInventory.InstallEvents();
            SteamNetworking.InstallEvents();
            SteamMatchmaking.InstallEvents();


            if (AutoCallbackUpdate)
            {
                RunCallbacksAsync().ContinueWith(
                    t =>
                    {
                        // Do nothing.
                    },
                    TaskContinuationOptions.OnlyOnFaulted);
            }
		}

		public static bool IsValid => initialized;

		public static async Task RunCallbacksAsync()
		{
			while ( IsValid )
			{
				await Task.Delay( 16 );
                if (!IsValid)
                    return;
				try
				{
					SteamAPI.RunCallbacks();
				}
				catch ( System.Exception )
				{
					// TODO - error outputs
				}
			}
		}

		public static void Shutdown()
		{
			Event.DisposeAllClient();

			initialized = false;

			SteamApps.Shutdown();
			SteamUtils.Shutdown();
			SteamParental.Shutdown();
			SteamMusic.Shutdown();
			SteamVideo.Shutdown();
			SteamUser.Shutdown();
			SteamFriends.Shutdown();
			SteamScreenshots.Shutdown();
			SteamUserStats.Shutdown();
			SteamInventory.Shutdown();
			SteamNetworking.Shutdown();
			SteamMatchmaking.Shutdown();

			SteamAPI.Shutdown();
		}

		internal static void RegisterCallback( IntPtr intPtr, int callbackId )
		{
			SteamAPI.RegisterCallback( intPtr, callbackId );
		}

		public static void RunCallbacks()
		{
			SteamAPI.RunCallbacks();
		}

		internal static void UnregisterCallback( IntPtr intPtr )
		{
			SteamAPI.UnregisterCallback( intPtr );
		}

		/// <summary>
		/// Checks if the current user's Steam client is connected to the Steam servers.
		/// If it's not then no real-time services provided by the Steamworks API will be enabled. The Steam 
		/// client will automatically be trying to recreate the connection as often as possible. When the 
		/// connection is restored a SteamServersConnected_t callback will be posted.
		/// You usually don't need to check for this yourself. All of the API calls that rely on this will 
		/// check internally. Forcefully disabling stuff when the player loses access is usually not a 
		/// very good experience for the player and you could be preventing them from accessing APIs that do not 
		/// need a live connection to Steam.
		/// </summary>
		public static bool IsLoggedOn => SteamUser.Internal.BLoggedOn();

		/// <summary>
		/// Gets the Steam ID of the account currently logged into the Steam client. This is 
		/// commonly called the 'current user', or 'local user'.
		/// A Steam ID is a unique identifier for a Steam accounts, Steam groups, Lobbies and Chat 
		/// rooms, and used to differentiate users in all parts of the Steamworks API.
		/// </summary>
		public static SteamId SteamId => SteamUser.Internal.GetSteamID();

		/// <summary>
		/// returns the local players name - guaranteed to not be NULL.
		/// this is the same name as on the users community profile page
		/// </summary>
		public static string Name => SteamFriends.Internal.GetPersonaName();

		/// <summary>
		/// gets the status of the current user
		/// </summary>
		public static FriendState State => SteamFriends.Internal.GetPersonaState();

		/// <summary>
		/// returns the appID of the current process
		/// </summary>
		public static AppId AppId { get; internal set; }
	}
}