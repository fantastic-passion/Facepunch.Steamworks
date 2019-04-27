using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	internal class ISteamInventory : SteamInterface
	{
		public ISteamInventory( bool server = false ) : base( server )
		{
		}
		
		public override string InterfaceName => "STEAMINVENTORY_INTERFACE_V003";
		
		public override void InitInternals()
		{
			_GetResultStatus = Marshal.GetDelegateForFunctionPointer<FGetResultStatus>( Marshal.ReadIntPtr( VTable, 0) );
			_GetResultItems = Marshal.GetDelegateForFunctionPointer<FGetResultItems>( Marshal.ReadIntPtr( VTable, 8) );
			_GetResultItemProperty = Marshal.GetDelegateForFunctionPointer<FGetResultItemProperty>( Marshal.ReadIntPtr( VTable, 16) );
			_GetResultTimestamp = Marshal.GetDelegateForFunctionPointer<FGetResultTimestamp>( Marshal.ReadIntPtr( VTable, 24) );
			_CheckResultSteamID = Marshal.GetDelegateForFunctionPointer<FCheckResultSteamID>( Marshal.ReadIntPtr( VTable, 32) );
			_DestroyResult = Marshal.GetDelegateForFunctionPointer<FDestroyResult>( Marshal.ReadIntPtr( VTable, 40) );
			_GetAllItems = Marshal.GetDelegateForFunctionPointer<FGetAllItems>( Marshal.ReadIntPtr( VTable, 48) );
			_GetItemsByID = Marshal.GetDelegateForFunctionPointer<FGetItemsByID>( Marshal.ReadIntPtr( VTable, 56) );
			_SerializeResult = Marshal.GetDelegateForFunctionPointer<FSerializeResult>( Marshal.ReadIntPtr( VTable, 64) );
			_DeserializeResult = Marshal.GetDelegateForFunctionPointer<FDeserializeResult>( Marshal.ReadIntPtr( VTable, 72) );
			_GenerateItems = Marshal.GetDelegateForFunctionPointer<FGenerateItems>( Marshal.ReadIntPtr( VTable, 80) );
			_GrantPromoItems = Marshal.GetDelegateForFunctionPointer<FGrantPromoItems>( Marshal.ReadIntPtr( VTable, 88) );
			_AddPromoItem = Marshal.GetDelegateForFunctionPointer<FAddPromoItem>( Marshal.ReadIntPtr( VTable, 96) );
			_AddPromoItems = Marshal.GetDelegateForFunctionPointer<FAddPromoItems>( Marshal.ReadIntPtr( VTable, 104) );
			_ConsumeItem = Marshal.GetDelegateForFunctionPointer<FConsumeItem>( Marshal.ReadIntPtr( VTable, 112) );
			_ExchangeItems = Marshal.GetDelegateForFunctionPointer<FExchangeItems>( Marshal.ReadIntPtr( VTable, 120) );
			_TransferItemQuantity = Marshal.GetDelegateForFunctionPointer<FTransferItemQuantity>( Marshal.ReadIntPtr( VTable, 128) );
			_SendItemDropHeartbeat = Marshal.GetDelegateForFunctionPointer<FSendItemDropHeartbeat>( Marshal.ReadIntPtr( VTable, 136) );
			_TriggerItemDrop = Marshal.GetDelegateForFunctionPointer<FTriggerItemDrop>( Marshal.ReadIntPtr( VTable, 144) );
			_TradeItems = Marshal.GetDelegateForFunctionPointer<FTradeItems>( Marshal.ReadIntPtr( VTable, 152) );
			_LoadItemDefinitions = Marshal.GetDelegateForFunctionPointer<FLoadItemDefinitions>( Marshal.ReadIntPtr( VTable, 160) );
			_GetItemDefinitionIDs = Marshal.GetDelegateForFunctionPointer<FGetItemDefinitionIDs>( Marshal.ReadIntPtr( VTable, 168) );
			_GetItemDefinitionProperty = Marshal.GetDelegateForFunctionPointer<FGetItemDefinitionProperty>( Marshal.ReadIntPtr( VTable, 176) );
			_RequestEligiblePromoItemDefinitionsIDs = Marshal.GetDelegateForFunctionPointer<FRequestEligiblePromoItemDefinitionsIDs>( Marshal.ReadIntPtr( VTable, 184) );
			_GetEligiblePromoItemDefinitionIDs = Marshal.GetDelegateForFunctionPointer<FGetEligiblePromoItemDefinitionIDs>( Marshal.ReadIntPtr( VTable, 192) );
			_StartPurchase = Marshal.GetDelegateForFunctionPointer<FStartPurchase>( Marshal.ReadIntPtr( VTable, 200) );
			_RequestPrices = Marshal.GetDelegateForFunctionPointer<FRequestPrices>( Marshal.ReadIntPtr( VTable, 208) );
			_GetNumItemsWithPrices = Marshal.GetDelegateForFunctionPointer<FGetNumItemsWithPrices>( Marshal.ReadIntPtr( VTable, 216) );
			_GetItemsWithPrices = Marshal.GetDelegateForFunctionPointer<FGetItemsWithPrices>( Marshal.ReadIntPtr( VTable, 224) );
			_GetItemPrice = Marshal.GetDelegateForFunctionPointer<FGetItemPrice>( Marshal.ReadIntPtr( VTable, 232) );
			_StartUpdateProperties = Marshal.GetDelegateForFunctionPointer<FStartUpdateProperties>( Marshal.ReadIntPtr( VTable, 240) );
			_RemoveProperty = Marshal.GetDelegateForFunctionPointer<FRemoveProperty>( Marshal.ReadIntPtr( VTable, 248) );
			_SetProperty1 = Marshal.GetDelegateForFunctionPointer<FSetProperty1>( Marshal.ReadIntPtr( VTable, 256) );
			_SetProperty2 = Marshal.GetDelegateForFunctionPointer<FSetProperty2>( Marshal.ReadIntPtr( VTable, 264) );
			_SetProperty3 = Marshal.GetDelegateForFunctionPointer<FSetProperty3>( Marshal.ReadIntPtr( VTable, 272) );
			_SetProperty4 = Marshal.GetDelegateForFunctionPointer<FSetProperty4>( Marshal.ReadIntPtr( VTable, 280) );
			_SubmitUpdateProperties = Marshal.GetDelegateForFunctionPointer<FSubmitUpdateProperties>( Marshal.ReadIntPtr( VTable, 288) );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate Result FGetResultStatus( IntPtr self, SteamInventoryResult_t resultHandle );
		private FGetResultStatus _GetResultStatus;
		
		#endregion
		internal Result GetResultStatus( SteamInventoryResult_t resultHandle )
		{
			return _GetResultStatus( Self, resultHandle );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetResultItems( IntPtr self, SteamInventoryResult_t resultHandle, [In,Out] SteamItemDetails_t[]  pOutItemsArray, ref uint punOutItemsArraySize );
		private FGetResultItems _GetResultItems;
		
		#endregion
		internal bool GetResultItems( SteamInventoryResult_t resultHandle, [In,Out] SteamItemDetails_t[]  pOutItemsArray, ref uint punOutItemsArraySize )
		{
			return _GetResultItems( Self, resultHandle, pOutItemsArray, ref punOutItemsArraySize );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetResultItemProperty( IntPtr self, SteamInventoryResult_t resultHandle, uint unItemIndex, string pchPropertyName, StringBuilder pchValueBuffer, ref uint punValueBufferSizeOut );
		private FGetResultItemProperty _GetResultItemProperty;
		
		#endregion
		internal bool GetResultItemProperty( SteamInventoryResult_t resultHandle, uint unItemIndex, string pchPropertyName, StringBuilder pchValueBuffer, ref uint punValueBufferSizeOut )
		{
			return _GetResultItemProperty( Self, resultHandle, unItemIndex, pchPropertyName, pchValueBuffer, ref punValueBufferSizeOut );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate uint FGetResultTimestamp( IntPtr self, SteamInventoryResult_t resultHandle );
		private FGetResultTimestamp _GetResultTimestamp;
		
		#endregion
		internal uint GetResultTimestamp( SteamInventoryResult_t resultHandle )
		{
			return _GetResultTimestamp( Self, resultHandle );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FCheckResultSteamID( IntPtr self, SteamInventoryResult_t resultHandle, SteamId steamIDExpected );
		private FCheckResultSteamID _CheckResultSteamID;
		
		#endregion
		internal bool CheckResultSteamID( SteamInventoryResult_t resultHandle, SteamId steamIDExpected )
		{
			return _CheckResultSteamID( Self, resultHandle, steamIDExpected );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate void FDestroyResult( IntPtr self, SteamInventoryResult_t resultHandle );
		private FDestroyResult _DestroyResult;
		
		#endregion
		internal void DestroyResult( SteamInventoryResult_t resultHandle )
		{
			_DestroyResult( Self, resultHandle );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetAllItems( IntPtr self, ref SteamInventoryResult_t pResultHandle );
		private FGetAllItems _GetAllItems;
		
		#endregion
		internal bool GetAllItems( ref SteamInventoryResult_t pResultHandle )
		{
			return _GetAllItems( Self, ref pResultHandle );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetItemsByID( IntPtr self, ref SteamInventoryResult_t pResultHandle, ref SteamItemInstanceID_t pInstanceIDs, uint unCountInstanceIDs );
		private FGetItemsByID _GetItemsByID;
		
		#endregion
		internal bool GetItemsByID( ref SteamInventoryResult_t pResultHandle, ref SteamItemInstanceID_t pInstanceIDs, uint unCountInstanceIDs )
		{
			return _GetItemsByID( Self, ref pResultHandle, ref pInstanceIDs, unCountInstanceIDs );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FSerializeResult( IntPtr self, SteamInventoryResult_t resultHandle, [In,Out] IntPtr[]  pOutBuffer, ref uint punOutBufferSize );
		private FSerializeResult _SerializeResult;
		
		#endregion
		internal bool SerializeResult( SteamInventoryResult_t resultHandle, [In,Out] IntPtr[]  pOutBuffer, ref uint punOutBufferSize )
		{
			return _SerializeResult( Self, resultHandle, pOutBuffer, ref punOutBufferSize );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FDeserializeResult( IntPtr self, [In,Out] SteamInventoryResult_t[]  pOutResultHandle, IntPtr pBuffer, uint unBufferSize, [MarshalAs( UnmanagedType.U1 )] bool bRESERVED_MUST_BE_FALSE );
		private FDeserializeResult _DeserializeResult;
		
		#endregion
		internal bool DeserializeResult( [In,Out] SteamInventoryResult_t[]  pOutResultHandle, IntPtr pBuffer, uint unBufferSize, [MarshalAs( UnmanagedType.U1 )] bool bRESERVED_MUST_BE_FALSE )
		{
			return _DeserializeResult( Self, pOutResultHandle, pBuffer, unBufferSize, bRESERVED_MUST_BE_FALSE );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGenerateItems( IntPtr self, ref SteamInventoryResult_t pResultHandle, [In,Out] SteamItemDef_t[]  pArrayItemDefs, [In,Out] uint[]  punArrayQuantity, uint unArrayLength );
		private FGenerateItems _GenerateItems;
		
		#endregion
		internal bool GenerateItems( ref SteamInventoryResult_t pResultHandle, [In,Out] SteamItemDef_t[]  pArrayItemDefs, [In,Out] uint[]  punArrayQuantity, uint unArrayLength )
		{
			return _GenerateItems( Self, ref pResultHandle, pArrayItemDefs, punArrayQuantity, unArrayLength );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGrantPromoItems( IntPtr self, ref SteamInventoryResult_t pResultHandle );
		private FGrantPromoItems _GrantPromoItems;
		
		#endregion
		internal bool GrantPromoItems( ref SteamInventoryResult_t pResultHandle )
		{
			return _GrantPromoItems( Self, ref pResultHandle );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FAddPromoItem( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef );
		private FAddPromoItem _AddPromoItem;
		
		#endregion
		internal bool AddPromoItem( ref SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef )
		{
			return _AddPromoItem( Self, ref pResultHandle, itemDef );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FAddPromoItems( IntPtr self, ref SteamInventoryResult_t pResultHandle, [In,Out] SteamItemDef_t[]  pArrayItemDefs, uint unArrayLength );
		private FAddPromoItems _AddPromoItems;
		
		#endregion
		internal bool AddPromoItems( ref SteamInventoryResult_t pResultHandle, [In,Out] SteamItemDef_t[]  pArrayItemDefs, uint unArrayLength )
		{
			return _AddPromoItems( Self, ref pResultHandle, pArrayItemDefs, unArrayLength );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FConsumeItem( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity );
		private FConsumeItem _ConsumeItem;
		
		#endregion
		internal bool ConsumeItem( ref SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity )
		{
			return _ConsumeItem( Self, ref pResultHandle, itemConsume, unQuantity );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FExchangeItems( IntPtr self, ref SteamInventoryResult_t pResultHandle, ref SteamItemDef_t pArrayGenerate, ref uint punArrayGenerateQuantity, uint unArrayGenerateLength, ref SteamItemInstanceID_t pArrayDestroy, ref uint punArrayDestroyQuantity, uint unArrayDestroyLength );
		private FExchangeItems _ExchangeItems;
		
		#endregion
		internal bool ExchangeItems( ref SteamInventoryResult_t pResultHandle, ref SteamItemDef_t pArrayGenerate, ref uint punArrayGenerateQuantity, uint unArrayGenerateLength, ref SteamItemInstanceID_t pArrayDestroy, ref uint punArrayDestroyQuantity, uint unArrayDestroyLength )
		{
			return _ExchangeItems( Self, ref pResultHandle, ref pArrayGenerate, ref punArrayGenerateQuantity, unArrayGenerateLength, ref pArrayDestroy, ref punArrayDestroyQuantity, unArrayDestroyLength );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FTransferItemQuantity( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest );
		private FTransferItemQuantity _TransferItemQuantity;
		
		#endregion
		internal bool TransferItemQuantity( ref SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest )
		{
			return _TransferItemQuantity( Self, ref pResultHandle, itemIdSource, unQuantity, itemIdDest );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate void FSendItemDropHeartbeat( IntPtr self );
		private FSendItemDropHeartbeat _SendItemDropHeartbeat;
		
		#endregion
		internal void SendItemDropHeartbeat()
		{
			_SendItemDropHeartbeat( Self );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FTriggerItemDrop( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition );
		private FTriggerItemDrop _TriggerItemDrop;
		
		#endregion
		internal bool TriggerItemDrop( ref SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition )
		{
			return _TriggerItemDrop( Self, ref pResultHandle, dropListDefinition );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FTradeItems( IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamId steamIDTradePartner, ref SteamItemInstanceID_t pArrayGive, ref uint pArrayGiveQuantity, uint nArrayGiveLength, ref SteamItemInstanceID_t pArrayGet, ref uint pArrayGetQuantity, uint nArrayGetLength );
		private FTradeItems _TradeItems;
		
		#endregion
		internal bool TradeItems( ref SteamInventoryResult_t pResultHandle, SteamId steamIDTradePartner, ref SteamItemInstanceID_t pArrayGive, ref uint pArrayGiveQuantity, uint nArrayGiveLength, ref SteamItemInstanceID_t pArrayGet, ref uint pArrayGetQuantity, uint nArrayGetLength )
		{
			return _TradeItems( Self, ref pResultHandle, steamIDTradePartner, ref pArrayGive, ref pArrayGiveQuantity, nArrayGiveLength, ref pArrayGet, ref pArrayGetQuantity, nArrayGetLength );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FLoadItemDefinitions( IntPtr self );
		private FLoadItemDefinitions _LoadItemDefinitions;
		
		#endregion
		internal bool LoadItemDefinitions()
		{
			return _LoadItemDefinitions( Self );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetItemDefinitionIDs( IntPtr self, ref SteamItemDef_t pItemDefIDs, ref uint punItemDefIDsArraySize );
		private FGetItemDefinitionIDs _GetItemDefinitionIDs;
		
		#endregion
		internal bool GetItemDefinitionIDs( ref SteamItemDef_t pItemDefIDs, ref uint punItemDefIDsArraySize )
		{
			return _GetItemDefinitionIDs( Self, ref pItemDefIDs, ref punItemDefIDsArraySize );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetItemDefinitionProperty( IntPtr self, SteamItemDef_t iDefinition, string pchPropertyName, StringBuilder pchValueBuffer, ref uint punValueBufferSizeOut );
		private FGetItemDefinitionProperty _GetItemDefinitionProperty;
		
		#endregion
		internal bool GetItemDefinitionProperty( SteamItemDef_t iDefinition, string pchPropertyName, StringBuilder pchValueBuffer, ref uint punValueBufferSizeOut )
		{
			return _GetItemDefinitionProperty( Self, iDefinition, pchPropertyName, pchValueBuffer, ref punValueBufferSizeOut );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate SteamAPICall_t FRequestEligiblePromoItemDefinitionsIDs( IntPtr self, SteamId steamID );
		private FRequestEligiblePromoItemDefinitionsIDs _RequestEligiblePromoItemDefinitionsIDs;
		
		#endregion
		internal async Task<SteamInventoryEligiblePromoItemDefIDs_t?> RequestEligiblePromoItemDefinitionsIDs( SteamId steamID )
		{
			return await (new Result<SteamInventoryEligiblePromoItemDefIDs_t>( _RequestEligiblePromoItemDefinitionsIDs( Self, steamID ) )).GetResult();
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetEligiblePromoItemDefinitionIDs( IntPtr self, SteamId steamID, ref SteamItemDef_t pItemDefIDs, ref uint punItemDefIDsArraySize );
		private FGetEligiblePromoItemDefinitionIDs _GetEligiblePromoItemDefinitionIDs;
		
		#endregion
		internal bool GetEligiblePromoItemDefinitionIDs( SteamId steamID, ref SteamItemDef_t pItemDefIDs, ref uint punItemDefIDsArraySize )
		{
			return _GetEligiblePromoItemDefinitionIDs( Self, steamID, ref pItemDefIDs, ref punItemDefIDsArraySize );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate SteamAPICall_t FStartPurchase( IntPtr self, [In,Out] SteamItemDef_t[]  pArrayItemDefs, [In,Out] uint[]  punArrayQuantity, uint unArrayLength );
		private FStartPurchase _StartPurchase;
		
		#endregion
		internal async Task<SteamInventoryStartPurchaseResult_t?> StartPurchase( [In,Out] SteamItemDef_t[]  pArrayItemDefs, [In,Out] uint[]  punArrayQuantity, uint unArrayLength )
		{
			return await (new Result<SteamInventoryStartPurchaseResult_t>( _StartPurchase( Self, pArrayItemDefs, punArrayQuantity, unArrayLength ) )).GetResult();
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate SteamAPICall_t FRequestPrices( IntPtr self );
		private FRequestPrices _RequestPrices;
		
		#endregion
		internal async Task<SteamInventoryRequestPricesResult_t?> RequestPrices()
		{
			return await (new Result<SteamInventoryRequestPricesResult_t>( _RequestPrices( Self ) )).GetResult();
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate uint FGetNumItemsWithPrices( IntPtr self );
		private FGetNumItemsWithPrices _GetNumItemsWithPrices;
		
		#endregion
		internal uint GetNumItemsWithPrices()
		{
			return _GetNumItemsWithPrices( Self );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetItemsWithPrices( IntPtr self, [In,Out] SteamItemDef_t[]  pArrayItemDefs, [In,Out] ulong[]  pCurrentPrices, [In,Out] ulong[]  pBasePrices, uint unArrayLength );
		private FGetItemsWithPrices _GetItemsWithPrices;
		
		#endregion
		internal bool GetItemsWithPrices( [In,Out] SteamItemDef_t[]  pArrayItemDefs, [In,Out] ulong[]  pCurrentPrices, [In,Out] ulong[]  pBasePrices, uint unArrayLength )
		{
			return _GetItemsWithPrices( Self, pArrayItemDefs, pCurrentPrices, pBasePrices, unArrayLength );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetItemPrice( IntPtr self, SteamItemDef_t iDefinition, ref ulong pCurrentPrice, ref ulong pBasePrice );
		private FGetItemPrice _GetItemPrice;
		
		#endregion
		internal bool GetItemPrice( SteamItemDef_t iDefinition, ref ulong pCurrentPrice, ref ulong pBasePrice )
		{
			return _GetItemPrice( Self, iDefinition, ref pCurrentPrice, ref pBasePrice );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate SteamInventoryUpdateHandle_t FStartUpdateProperties( IntPtr self );
		private FStartUpdateProperties _StartUpdateProperties;
		
		#endregion
		internal SteamInventoryUpdateHandle_t StartUpdateProperties()
		{
			return _StartUpdateProperties( Self );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FRemoveProperty( IntPtr self, SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName );
		private FRemoveProperty _RemoveProperty;
		
		#endregion
		internal bool RemoveProperty( SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName )
		{
			return _RemoveProperty( Self, handle, nItemID, pchPropertyName );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FSetProperty1( IntPtr self, SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, string pchPropertyValue );
		private FSetProperty1 _SetProperty1;
		
		#endregion
		internal bool SetProperty1( SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, string pchPropertyValue )
		{
			return _SetProperty1( Self, handle, nItemID, pchPropertyName, pchPropertyValue );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FSetProperty2( IntPtr self, SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, [MarshalAs( UnmanagedType.U1 )] bool bValue );
		private FSetProperty2 _SetProperty2;
		
		#endregion
		internal bool SetProperty2( SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, [MarshalAs( UnmanagedType.U1 )] bool bValue )
		{
			return _SetProperty2( Self, handle, nItemID, pchPropertyName, bValue );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FSetProperty3( IntPtr self, SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, long nValue );
		private FSetProperty3 _SetProperty3;
		
		#endregion
		internal bool SetProperty3( SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, long nValue )
		{
			return _SetProperty3( Self, handle, nItemID, pchPropertyName, nValue );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FSetProperty4( IntPtr self, SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, float flValue );
		private FSetProperty4 _SetProperty4;
		
		#endregion
		internal bool SetProperty4( SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, float flValue )
		{
			return _SetProperty4( Self, handle, nItemID, pchPropertyName, flValue );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FSubmitUpdateProperties( IntPtr self, SteamInventoryUpdateHandle_t handle, ref SteamInventoryResult_t pResultHandle );
		private FSubmitUpdateProperties _SubmitUpdateProperties;
		
		#endregion
		internal bool SubmitUpdateProperties( SteamInventoryUpdateHandle_t handle, ref SteamInventoryResult_t pResultHandle )
		{
			return _SubmitUpdateProperties( Self, handle, ref pResultHandle );
		}
		
	}
}
