//=========================================================================  
// CopyRight (C) 2005-2014 温州市捷点信息技术有限公司 All Rights Reserved.  
//=========================================================================  
using System;
using System.Text;
using System.ComponentModel;
using CNVP.Framework.DataAccess;
using CNVP.Framework.Utils;

namespace CNVP.Model
{
    [Description("安全适运申报单")]
    [Key("Id")]
    public class SCW : DbUtils<SCW>
    {
        private int? _Id = null;
        /// <summary>  
        /// Id  
        /// </summary>  
        /// <returns></returns>  
        [Description("Id")]
        public int? Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }
        private string _AppGuid = null;
        /// <summary>  
        /// 申请单AppGuid  
        /// </summary>  
        /// <returns></returns>  
        [Description("申请单AppGuid")]
        public string AppGuid
        {
            get
            {
                return this._AppGuid;
            }
            set
            {
                this._AppGuid = value;
            }
        }
        private string _GoodsName = null;
        /// <summary>  
        /// 散装货物运输名称  
        /// </summary>  
        /// <returns></returns>  
        [Description("散装货物运输名称")]
        public string GoodsName
        {
            get
            {
                return this._GoodsName;
            }
            set
            {
                this._GoodsName = value;
            }
        }
        private string _Shipper = null;
        /// <summary>  
        /// 托运人  
        /// </summary>  
        /// <returns></returns>  
        [Description("托运人")]
        public string Shipper
        {
            get
            {
                return this._Shipper;
            }
            set
            {
                this._Shipper = value;
            }
        }
        private string _TransportDocNo = null;
        /// <summary>  
        /// 运输单证编号  
        /// </summary>  
        /// <returns></returns>  
        [Description("运输单证编号")]
        public string TransportDocNo
        {
            get
            {
                return this._TransportDocNo;
            }
            set
            {
                this._TransportDocNo = value;
            }
        }
        private string _Consignee = null;
        /// <summary>  
        /// 收货人  
        /// </summary>  
        /// <returns></returns>  
        [Description("收货人")]
        public string Consignee
        {
            get
            {
                return this._Consignee;
            }
            set
            {
                this._Consignee = value;
            }
        }
        private string _Carrier = null;
        /// <summary>  
        /// 承运人  
        /// </summary>  
        /// <returns></returns>  
        [Description("承运人")]
        public string Carrier
        {
            get
            {
                return this._Carrier;
            }
            set
            {
                this._Carrier = value;
            }
        }
        private string _TransPort = null;
        /// <summary>  
        /// 运输工具的名称/方式  
        /// </summary>  
        /// <returns></returns>  
        [Description("运输工具的名称/方式")]
        public string TransPort
        {
            get
            {
                return this._TransPort;
            }
            set
            {
                this._TransPort = value;
            }
        }
        private string _Guide = null;
        /// <summary>  
        /// 指南或其他事项  
        /// </summary>  
        /// <returns></returns>  
        [Description("指南或其他事项")]
        public string Guide
        {
            get
            {
                return this._Guide;
            }
            set
            {
                this._Guide = value;
            }
        }
        private string _HomePort = null;
        /// <summary>  
        /// 出发港口/地点  
        /// </summary>  
        /// <returns></returns>  
        [Description("出发港口/地点")]
        public string HomePort
        {
            get
            {
                return this._HomePort;
            }
            set
            {
                this._HomePort = value;
            }
        }
        private string _DestinationPort = null;
        /// <summary>  
        /// 目的港口/地点  
        /// </summary>  
        /// <returns></returns>  
        [Description("目的港口/地点")]
        public string DestinationPort
        {
            get
            {
                return this._DestinationPort;
            }
            set
            {
                this._DestinationPort = value;
            }
        }
        private string _Description = null;
        /// <summary>  
        /// 货物一般性的描述  
        /// </summary>  
        /// <returns></returns>  
        [Description("货物一般性的描述")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }
        private string _TotalWeight = null;
        /// <summary>  
        /// 总重  
        /// </summary>  
        /// <returns></returns>  
        [Description("总重")]
        public string TotalWeight
        {
            get
            {
                return this._TotalWeight;
            }
            set
            {
                this._TotalWeight = value;
            }
        }
        private string _GoodsGroup = null;
        /// <summary>  
        /// 货物组别  
        /// </summary>  
        /// <returns></returns>  
        [Description("货物组别")]
        public string GoodsGroup
        {
            get
            {
                return this._GoodsGroup;
            }
            set
            {
                this._GoodsGroup = value;
            }
        }  
        private string _MoistureLimit = null;
        /// <summary>  
        /// 适运水分极限  
        /// </summary>  
        /// <returns></returns>  
        [Description("适运水分极限")]
        public string MoistureLimit
        {
            get
            {
                return this._MoistureLimit;
            }
            set
            {
                this._MoistureLimit = value;
            }
        }
        private string _ParticularNature = null;
        /// <summary>  
        /// 特殊性质  
        /// </summary>  
        /// <returns></returns>  
        [Description("特殊性质")]
        public string ParticularNature
        {
            get
            {
                return this._ParticularNature;
            }
            set
            {
                this._ParticularNature = value;
            }
        }
        private string _ExatrCertificate = null;
        /// <summary>  
        /// 额外证书  
        /// </summary>  
        /// <returns></returns>  
        [Description("额外证书")]
        public string ExatrCertificate
        {
            get
            {
                return this._ExatrCertificate;
            }
            set
            {
                this._ExatrCertificate = value;
            }
        }
        private string _ExatrCertificateDec = null;
        /// <summary>  
        /// 额外证书其他说明  
        /// </summary>  
        /// <returns></returns>  
        [Description("额外证书其他说明")]
        public string ExatrCertificateDec
        {
            get
            {
                return this._ExatrCertificateDec;
            }
            set
            {
                this._ExatrCertificateDec = value;
            }
        }
        private DateTime? _CreateTime = null;
        /// <summary>  
        /// 申请时间  
        /// </summary>  
        /// <returns></returns>  
        [Description("申请时间")]
        public DateTime? CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                this._CreateTime = value;
            }
        }
        private string _PrintNum = null;
        /// <summary>  
        /// 打印序号  
        /// </summary>  
        /// <returns></returns>  
        [Description("打印序号")]
        public string PrintNum
        {
            get
            {
                return this._PrintNum;
            }
            set
            {
                this._PrintNum = value;
            }
        }
    }
}