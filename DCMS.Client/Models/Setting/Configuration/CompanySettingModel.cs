using System;
using System.Collections.Generic;

namespace Wesley.Client.Models.Configuration
{
    public class CompanySettingModel : EntityBase
    {

        #region 商品精细化

        //单据生产日期功能", "1、关闭生产日期：将清除所有商品库存中的生产日期信息。2、虚拟生产日期：仅在开销售单时录入生产日期,一般用于打印生产日期。3、全面开启生产日期：开启后，商品档案中可启用生产日期。启用生产日期的商品在所有影响库存的单据中都必须指定生产日期。")]
        public int OpenBillMakeDate { get; set; }
        public IEnumerable<SelectListItem> OpenBillMakeDates { get; set; }


        //多单位商品价格", "1、各价格不严格按照单位换算率计算。2、价格严格按照单位换算率计算。")]
        public int MulProductPriceUnit { get; set; }
        public IEnumerable<SelectListItem> MulProductPriceUnits { get; set; }


        //允许创建多个相同条码的商品", "允许创建多个相同条码的商品")]
        public bool AllowCreateMulSameBarcode { get; set; }

        #endregion

        #region 开单选项

        /// <summary>
        /// 默认价格体系方案(默认成本价)
        /// </summary>
        public string DefaultPricePlan { get; set; } = "0_5";

        //默认进价", "上次进价：采购订单、采购单在开单时，默认显示的价格为上一次开单时使用的价格;预设进价：开单时取商品档案中设定的进价。")]
        public int DefaultPurchasePrice { get; set; }
        public IEnumerable<SelectListItem> DefaultPurchasePrices { get; set; }

        //商品变价参考标准", "销售，退货商品价格与设置的参考价格不一致时，发生颜色变化，并提示变价字样。")]
        public int VariablePriceCommodity { get; set; }
        public IEnumerable<SelectListItem> VariablePriceCommodities { get; set; }


        //单据合计取整精度", "销售单，退货单，订货单在合计金额时，只精确到所设定的单位，超过设定部分的金额会舍去。例：实际金额为（1152.85）")]
        public int AccuracyRounding { get; set; }
        public IEnumerable<SelectListItem> AccuracyRoundings { get; set; }


        //开单展示条码", "开单展示条码")]
        public int MakeBillDisplayBarCode { get; set; }
        public IEnumerable<SelectListItem> MakeBillDisplayBarCodes { get; set; }

        //销售单/退货单交易日期只允许选择", "销售单/退货单交易日期只允许选择")]
        public int AllowSelectionDateRange { get; set; }


        //对接票证通系统", "可将销售单，销售订单上传至票证通系统")]
        public bool DockingTicketPassSystem { get; set; }


        //允许在销售订单和销售单中开退货商品", "简化销售和退货操作，便于合计金额")]
        public bool AllowReturnInSalesAndOrders { get; set; }


        //APP销售开单可指定送货员", "可以为销售单、退货单指定送货员")]
        public bool AppMaybeDeliveryPersonnel { get; set; }



        //App提交销售订单/退货订单后，系统自动审核", "App提交销售订单/退货订单后，系统自动审核")]
        public bool AppSubmitOrderAutoAudits { get; set; }


        //App提交调拨单后，系统自动审核", "App提交调拨单后，系统自动审核")]
        public bool AppSubmitTransferAutoAudits { get; set; }


        //App提交费用支出单后，系统自动审核", "App提交费用支出单后，系统自动审核")]
        public bool AppSubmitExpenseAutoAudits { get; set; }


        //App提交销售单/销售退货单后，系统自动审核", "App提交销售单/销售退货单后，系统自动审核")]
        public bool AppSubmitBillReturnAutoAudits { get; set; }


        //App允许红冲单据", "App允许红冲单据")]
        public bool AppAllowWriteBack { get; set; }


        //允许预收款支付成负数", "销售订单、退货订单、销售单、退货单、收款单，使用预收款支付时，支持预收款可以被支付成负数")]
        public bool AllowAdvancePaymentsNegative { get; set; }


        //只展示已开预收款单的预收款账户", "只展示已开预收款单的预收款账户")]
        public bool ShowOnlyPrepaidAccountsWithPrepaidReceipts { get; set; }



        //分口味核算库存商品，只打印主商品", "可以指定销售单，销售订单，退货单，退货订单中的分口味商品，只打印主商品")]
        public bool TasteByTasteAccountingOnlyPrintMainProduct { get; set; }

        #endregion

        #region 库存管理


        //App开销售单时只展示有库存商品", "App开销售单选商品时，只能筛选到库存大于零的商品")]
        public bool APPOnlyShowHasStockProduct { get; set; }


        //开单时显示订单占用库存", "开销售单，销售订单，调拨单，采购单将展示出订单占用的库存数量")]
        public bool APPShowOrderStock { get; set; }


        #endregion

        #region 业务员管理

        //业务员在店时间", "业务员在店时间")]
        public int OnStoreStopSeconds { get; set; }

        //业务员轨迹实时上报定位时间段", "App打开后，会自动根据所设定的频率上报位置")]
        public bool EnableSalesmanTrack { get; set; }


        //开始时间", "开始时间")]
        public DateTime Start { get; set; }


        //结束时间", "结束时间")]
        public DateTime End { get; set; }


        //定位轨迹上报频率", "定位轨迹上报频率")]
        public int FrequencyTimer { get; set; }


        //业务员只能看到自己片区的客户", "开单选客户，查看应收款等操作时，只能看到自己片区的客户")]
        public bool SalesmanOnlySeeHisCustomer { get; set; }


        //业务员必须先拜访门店才能开单", "该功能可以帮业务员养成拜访门店的习惯")]
        public bool SalesmanVisitStoreBefore { get; set; }


        //拜访必须拍门头照片", "拜访必须拍门头照片")]
        public bool SalesmanVisitMustPhotographed { get; set; }

        //允许开单距离
        public double SalesmanDeliveryDistance { get; set; } = 50;

        /// <summary>
        /// 门头照片数
        /// </summary>
        public int DoorheadPhotoNum { get; set; } = 1;

        /// <summary>
        /// 陈列照片数
        /// </summary>
        public int DisplayPhotoNum { get; set; } = 4;

        #endregion

        #region 财务管理


        //参考成本价", "预设进价：以商品档案中预设的进价为参考成本价。平均进价:以历史进货价的平均价为参考成本价。")]
        public int ReferenceCostPrice { get; set; }
        public IEnumerable<SelectListItem> ReferenceCostPrices { get; set; }


        //进货平均价计算历史次数", "进货平均价计算历史次数")]
        public int AveragePurchasePriceCalcNumber { get; set; }


        //允许负库存月结", "允许负库存月结")]
        public bool AllowNegativeInventoryMonthlyClosure { get; set; }

        #endregion

        #region 其他设置

        //启用税务功能", "启用税务功能")]
        public bool EnableTaxRate { get; set; }


        //税率", "启用后在销售单、销售订单、采购单、采购订单、采购退货单等单据中能看到税额")]
        public double TaxRate { get; set; }



        //门头陈列照片水印增加内容", "门头陈列照片水印增加内容")]
        public string PhotographedWater { get; set; }

        #endregion

    }


    /// <summary>
    /// 表示备注设置
    /// </summary>
    public partial class RemarkConfig : EntityBase
    {

        /// <summary>
        /// 备注名称       
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 参与价格记忆
        /// </summary>
        public bool RemberPrice { get; set; }

    }
}
