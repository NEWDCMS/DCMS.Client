using System;
using System.Collections.Generic;

namespace Wesley.Client.Models.Configuration
{
    public class CompanySettingModel : EntityBase
    {

        #region ��Ʒ��ϸ��

        //�����������ڹ���", "1���ر��������ڣ������������Ʒ����е�����������Ϣ��2�������������ڣ����ڿ����۵�ʱ¼����������,һ�����ڴ�ӡ�������ڡ�3��ȫ�濪���������ڣ���������Ʒ�����п������������ڡ������������ڵ���Ʒ������Ӱ����ĵ����ж�����ָ���������ڡ�")]
        public int OpenBillMakeDate { get; set; }
        public IEnumerable<SelectListItem> OpenBillMakeDates { get; set; }


        //�൥λ��Ʒ�۸�", "1�����۸��ϸ��յ�λ�����ʼ��㡣2���۸��ϸ��յ�λ�����ʼ��㡣")]
        public int MulProductPriceUnit { get; set; }
        public IEnumerable<SelectListItem> MulProductPriceUnits { get; set; }


        //�����������ͬ�������Ʒ", "�����������ͬ�������Ʒ")]
        public bool AllowCreateMulSameBarcode { get; set; }

        #endregion

        #region ����ѡ��

        /// <summary>
        /// Ĭ�ϼ۸���ϵ����(Ĭ�ϳɱ���)
        /// </summary>
        public string DefaultPricePlan { get; set; } = "0_5";

        //Ĭ�Ͻ���", "�ϴν��ۣ��ɹ��������ɹ����ڿ���ʱ��Ĭ����ʾ�ļ۸�Ϊ��һ�ο���ʱʹ�õļ۸�;Ԥ����ۣ�����ʱȡ��Ʒ�������趨�Ľ��ۡ�")]
        public int DefaultPurchasePrice { get; set; }
        public IEnumerable<SelectListItem> DefaultPurchasePrices { get; set; }

        //��Ʒ��۲ο���׼", "���ۣ��˻���Ʒ�۸������õĲο��۸�һ��ʱ��������ɫ�仯������ʾ���������")]
        public int VariablePriceCommodity { get; set; }
        public IEnumerable<SelectListItem> VariablePriceCommodities { get; set; }


        //���ݺϼ�ȡ������", "���۵����˻������������ںϼƽ��ʱ��ֻ��ȷ�����趨�ĵ�λ�������趨���ֵĽ�����ȥ������ʵ�ʽ��Ϊ��1152.85��")]
        public int AccuracyRounding { get; set; }
        public IEnumerable<SelectListItem> AccuracyRoundings { get; set; }


        //����չʾ����", "����չʾ����")]
        public int MakeBillDisplayBarCode { get; set; }
        public IEnumerable<SelectListItem> MakeBillDisplayBarCodes { get; set; }

        //���۵�/�˻�����������ֻ����ѡ��", "���۵�/�˻�����������ֻ����ѡ��")]
        public int AllowSelectionDateRange { get; set; }


        //�Խ�Ʊ֤ͨϵͳ", "�ɽ����۵������۶����ϴ���Ʊ֤ͨϵͳ")]
        public bool DockingTicketPassSystem { get; set; }


        //���������۶��������۵��п��˻���Ʒ", "�����ۺ��˻����������ںϼƽ��")]
        public bool AllowReturnInSalesAndOrders { get; set; }


        //APP���ۿ�����ָ���ͻ�Ա", "����Ϊ���۵����˻���ָ���ͻ�Ա")]
        public bool AppMaybeDeliveryPersonnel { get; set; }



        //App�ύ���۶���/�˻�������ϵͳ�Զ����", "App�ύ���۶���/�˻�������ϵͳ�Զ����")]
        public bool AppSubmitOrderAutoAudits { get; set; }


        //App�ύ��������ϵͳ�Զ����", "App�ύ��������ϵͳ�Զ����")]
        public bool AppSubmitTransferAutoAudits { get; set; }


        //App�ύ����֧������ϵͳ�Զ����", "App�ύ����֧������ϵͳ�Զ����")]
        public bool AppSubmitExpenseAutoAudits { get; set; }


        //App�ύ���۵�/�����˻�����ϵͳ�Զ����", "App�ύ���۵�/�����˻�����ϵͳ�Զ����")]
        public bool AppSubmitBillReturnAutoAudits { get; set; }


        //App�����嵥��", "App�����嵥��")]
        public bool AppAllowWriteBack { get; set; }


        //����Ԥ�տ�֧���ɸ���", "���۶������˻����������۵����˻������տ��ʹ��Ԥ�տ�֧��ʱ��֧��Ԥ�տ���Ա�֧���ɸ���")]
        public bool AllowAdvancePaymentsNegative { get; set; }


        //ֻչʾ�ѿ�Ԥ�տ��Ԥ�տ��˻�", "ֻչʾ�ѿ�Ԥ�տ��Ԥ�տ��˻�")]
        public bool ShowOnlyPrepaidAccountsWithPrepaidReceipts { get; set; }



        //�ֿ�ζ��������Ʒ��ֻ��ӡ����Ʒ", "����ָ�����۵������۶������˻������˻������еķֿ�ζ��Ʒ��ֻ��ӡ����Ʒ")]
        public bool TasteByTasteAccountingOnlyPrintMainProduct { get; set; }

        #endregion

        #region ������


        //App�����۵�ʱֻչʾ�п����Ʒ", "App�����۵�ѡ��Ʒʱ��ֻ��ɸѡ�������������Ʒ")]
        public bool APPOnlyShowHasStockProduct { get; set; }


        //����ʱ��ʾ����ռ�ÿ��", "�����۵������۶��������������ɹ�����չʾ������ռ�õĿ������")]
        public bool APPShowOrderStock { get; set; }


        #endregion

        #region ҵ��Ա����

        //ҵ��Ա�ڵ�ʱ��", "ҵ��Ա�ڵ�ʱ��")]
        public int OnStoreStopSeconds { get; set; }

        //ҵ��Ա�켣ʵʱ�ϱ���λʱ���", "App�򿪺󣬻��Զ��������趨��Ƶ���ϱ�λ��")]
        public bool EnableSalesmanTrack { get; set; }


        //��ʼʱ��", "��ʼʱ��")]
        public DateTime Start { get; set; }


        //����ʱ��", "����ʱ��")]
        public DateTime End { get; set; }


        //��λ�켣�ϱ�Ƶ��", "��λ�켣�ϱ�Ƶ��")]
        public int FrequencyTimer { get; set; }


        //ҵ��Աֻ�ܿ����Լ�Ƭ���Ŀͻ�", "����ѡ�ͻ����鿴Ӧ�տ�Ȳ���ʱ��ֻ�ܿ����Լ�Ƭ���Ŀͻ�")]
        public bool SalesmanOnlySeeHisCustomer { get; set; }


        //ҵ��Ա�����Ȱݷ��ŵ���ܿ���", "�ù��ܿ��԰�ҵ��Ա���ɰݷ��ŵ��ϰ��")]
        public bool SalesmanVisitStoreBefore { get; set; }


        //�ݷñ�������ͷ��Ƭ", "�ݷñ�������ͷ��Ƭ")]
        public bool SalesmanVisitMustPhotographed { get; set; }

        //����������
        public double SalesmanDeliveryDistance { get; set; } = 50;

        #endregion

        #region �������


        //�ο��ɱ���", "Ԥ����ۣ�����Ʒ������Ԥ��Ľ���Ϊ�ο��ɱ��ۡ�ƽ������:����ʷ�����۵�ƽ����Ϊ�ο��ɱ��ۡ�")]
        public int ReferenceCostPrice { get; set; }
        public IEnumerable<SelectListItem> ReferenceCostPrices { get; set; }


        //����ƽ���ۼ�����ʷ����", "����ƽ���ۼ�����ʷ����")]
        public int AveragePurchasePriceCalcNumber { get; set; }


        //��������½�", "��������½�")]
        public bool AllowNegativeInventoryMonthlyClosure { get; set; }

        #endregion

        #region ��������

        //����˰����", "����˰����")]
        public bool EnableTaxRate { get; set; }


        //˰��", "���ú������۵������۶������ɹ������ɹ��������ɹ��˻����ȵ������ܿ���˰��")]
        public double TaxRate { get; set; }



        //��ͷ������Ƭˮӡ��������", "��ͷ������Ƭˮӡ��������")]
        public string PhotographedWater { get; set; }

        #endregion


    }


    /// <summary>
    /// ��ʾ��ע����
    /// </summary>
    public partial class RemarkConfig : EntityBase
    {

        /// <summary>
        /// ��ע����       
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ����۸����
        /// </summary>
        public bool RemberPrice { get; set; }

    }
}
