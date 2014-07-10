using System;
using System.Collections.Generic;
using System.Text;

namespace CNVP.Model
{
    using System.ComponentModel;

    using CNVP.Framework.DataAccess;
    using CNVP.Framework.Utils;

    [Description("项目申请表")]
    [Key("Id")]
    public class Application : DbUtils<Application>
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
        private string _Guid = null;
        /// <summary>  
        /// Guid  
        /// </summary>  
        /// <returns></returns>  
        [Description("Guid")]
        public string Guid
        {
            get
            {
                return this._Guid;
            }
            set
            {
                this._Guid = value;
            }
        }  
        private int? _IO = null;
        /// <summary>  
        /// 出入港  
        /// </summary>  
        /// <returns></returns>  
        [Description("出入港")]
        public int? IO
        {
            get
            {
                return this._IO;
            }
            set
            {
                this._IO = value;
            }
        }
        private string _ShipName = null;
        /// <summary>  
        /// 船名  
        /// </summary>  
        /// <returns></returns>  
        [Description("船名")]
        public string ShipName
        {
            get
            {
                return this._ShipName;
            }
            set
            {
                this._ShipName = value;
            }
        }
        private string _Saillings = null;
        /// <summary>  
        /// 航次  
        /// </summary>  
        /// <returns></returns>  
        [Description("航次")]
        public string Saillings
        {
            get
            {
                return this._Saillings;
            }
            set
            {
                this._Saillings = value;
            }
        }
        private string _Nationality = null;
        /// <summary>  
        /// 国籍  
        /// </summary>  
        /// <returns></returns>  
        [Description("国籍")]
        public string Nationality
        {
            get
            {
                return this._Nationality;
            }
            set
            {
                this._Nationality = value;
            }
        }
        private string _Operator = null;
        /// <summary>  
        /// 经营人  
        /// </summary>  
        /// <returns></returns>  
        [Description("经营人")]
        public string Operator
        {
            get
            {
                return this._Operator;
            }
            set
            {
                this._Operator = value;
            }
        }
        private string _StartPort = null;
        /// <summary>  
        /// 始发港  
        /// </summary>  
        /// <returns></returns>  
        [Description("始发港")]
        public string StartPort
        {
            get
            {
                return this._StartPort;
            }
            set
            {
                this._StartPort = value;
            }
        }
        private DateTime? _ArrivedTime = null;
        /// <summary>  
        /// 抵港时间  
        /// </summary>  
        /// <returns></returns>  
        [Description("抵港时间")]
        public DateTime? ArrivedTime
        {
            get
            {
                return this._ArrivedTime;
            }
            set
            {
                this._ArrivedTime = value;
            }
        }
        private string _WorkBerth = null;
        /// <summary>  
        /// 作业泊位  
        /// </summary>  
        /// <returns></returns>  
        [Description("作业泊位")]
        public string WorkBerth
        {
            get
            {
                return this._WorkBerth;
            }
            set
            {
                this._WorkBerth = value;
            }
        }
        private DateTime? _WorkTime = null;
        /// <summary>  
        /// 作业时间  
        /// </summary>  
        /// <returns></returns>  
        [Description("作业时间")]
        public DateTime? WorkTime
        {
            get
            {
                return this._WorkTime;
            }
            set
            {
                this._WorkTime = value;
            }
        }
        private string _Declarer = null;
        /// <summary>  
        /// 申报员  
        /// </summary>  
        /// <returns></returns>  
        [Description("申报员")]
        public string Declarer
        {
            get
            {
                return this._Declarer;
            }
            set
            {
                this._Declarer = value;
            }
        }
        private string _DecCertificateNo = null;
        /// <summary>  
        /// 申报员证书编号  
        /// </summary>  
        /// <returns></returns>  
        [Description("申报员证书编号")]
        public string DecCertificateNo
        {
            get
            {
                return this._DecCertificateNo;
            }
            set
            {
                this._DecCertificateNo = value;
            }
        }
        private string _Ship = null;
        /// <summary>  
        /// 船方  
        /// </summary>  
        /// <returns></returns>  
        [Description("船方")]
        public string Ship
        {
            get
            {
                return this._Ship;
            }
            set
            {
                this._Ship = value;
            }
        }
        private string _Telphone = null;
        /// <summary>  
        /// 手机  
        /// </summary>  
        /// <returns></returns>  
        [Description("手机")]
        public string Telphone
        {
            get
            {
                return this._Telphone;
            }
            set
            {
                this._Telphone = value;
            }
        }
        private int? _AppState = null;
        /// <summary>  
        /// 申请单状态  
        /// </summary>  
        /// <returns></returns>  
        [Description("申请单状态")]
        public int? AppState
        {
            get
            {
                return this._AppState;
            }
            set
            {
                this._AppState = value;
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
        private int? _UserId = null;
        /// <summary>  
        /// 申报人Id  
        /// </summary>  
        /// <returns></returns>  
        [Description("申报人Id")]
        public int? UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                this._UserId = value;
            }
        }
        private string _EmergencyName = null;
        /// <summary>  
        /// 手机  
        /// </summary>  
        /// <returns></returns>  
        [Description("紧急联系人姓名")]
        public string EmergencyName
        {
            get
            {
                return this._EmergencyName;
            }
            set
            {
                this._EmergencyName = value;
            }
        }
        private string _EmergencyTel = null;
        /// <summary>  
        /// 手机  
        /// </summary>  
        /// <returns></returns>  
        [Description("紧急联系人电话")]
        public string EmergencyTel
        {
            get
            {
                return this._EmergencyTel;
            }
            set
            {
                this._EmergencyTel = value;
            }
        }
        private string _EmergencyFax = null;
        /// <summary>  
        /// 手机  
        /// </summary>  
        /// <returns></returns>  
        [Description("紧急联系人传真")]
        public string EmergencyFax
        {
            get
            {
                return this._EmergencyFax;
            }
            set
            {
                this._EmergencyFax = value;
            }
        }
        private string _RmergencyEmail = null;
        /// <summary>  
        /// 手机  
        /// </summary>  
        /// <returns></returns>  
        [Description("紧急联系人邮件")]
        public string RmergencyEmail
        {
            get
            {
                return this._RmergencyEmail;
            }
            set
            {
                this._RmergencyEmail = value;
            }
        }
    }
}