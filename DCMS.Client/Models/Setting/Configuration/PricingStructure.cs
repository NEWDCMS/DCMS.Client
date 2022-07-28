using System;
namespace Wesley.Client.Models.Configuration
{

    /// <summary>
    /// ��ʾ�۸���ϵ����
    /// </summary>
    public partial class PricingStructure : EntityBase
    {
        /// <summary>
        /// �۸���ϵ���
        /// </summary>
        public int PriceType { get; set; }

        /// <summary>
        /// �ͻ�
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int? ChannelId { get; set; }

        /// <summary>
        /// Ƭ��
        /// </summary>
        public string DistrictIds { get; set; }

        /// <summary>
        /// Ƭ��
        /// </summary>
        public string DistrictName { get; set; }


        /// <summary>
        /// �ȼ�
        /// </summary>

        public int? EndPointLevel { get; set; }

        /// <summary>
        /// ��ѡ�۸�
        /// </summary>
        public string PreferredPrice { get; set; }

        /// <summary>
        /// ��ѡ�۸�
        /// </summary>
        public string SecondaryPrice { get; set; }

        /// <summary>
        /// ĩѡ�۸�
        /// </summary>
        public string FinalPrice { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Ȩ��
        /// </summary>
        public int Order { get; set; }
    }
}
