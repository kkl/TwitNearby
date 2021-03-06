﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 2009/7/18 下午 10:59:52
namespace TwitsNearby.Models
{
    
    /// <summary>
    /// There are no comments for TwitsNearByEntities in the schema.
    /// </summary>
    public partial class TwitsNearByEntities : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new TwitsNearByEntities object using the connection string found in the 'TwitsNearByEntities' section of the application configuration file.
        /// </summary>
        public TwitsNearByEntities() : 
                base("name=TwitsNearByEntities", "TwitsNearByEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new TwitsNearByEntities object.
        /// </summary>
        public TwitsNearByEntities(string connectionString) : 
                base(connectionString, "TwitsNearByEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new TwitsNearByEntities object.
        /// </summary>
        public TwitsNearByEntities(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "TwitsNearByEntities")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for Statuses in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<Statuses> Statuses
        {
            get
            {
                if ((this._Statuses == null))
                {
                    this._Statuses = base.CreateQuery<Statuses>("[Statuses]");
                }
                return this._Statuses;
            }
        }
        private global::System.Data.Objects.ObjectQuery<Statuses> _Statuses;
        /// <summary>
        /// There are no comments for Statuses in the schema.
        /// </summary>
        public void AddToStatuses(Statuses statuses)
        {
            base.AddObject("Statuses", statuses);
        }
    }
    /// <summary>
    /// There are no comments for TwitsNearByModel.Statuses in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ID
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="TwitsNearByModel", Name="Statuses")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class Statuses : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new Statuses object.
        /// </summary>
        /// <param name="statusID">Initial value of StatusID.</param>
        /// <param name="createDT">Initial value of CreateDT.</param>
        /// <param name="id">Initial value of ID.</param>
        public static Statuses CreateStatuses(long statusID, global::System.DateTime createDT, global::System.Guid id)
        {
            Statuses statuses = new Statuses();
            statuses.StatusID = statusID;
            statuses.CreateDT = createDT;
            statuses.ID = id;
            return statuses;
        }
        /// <summary>
        /// There are no comments for Property StatusID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public long StatusID
        {
            get
            {
                return this._StatusID;
            }
            set
            {
                this.OnStatusIDChanging(value);
                this.ReportPropertyChanging("StatusID");
                this._StatusID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("StatusID");
                this.OnStatusIDChanged();
            }
        }
        private long _StatusID;
        partial void OnStatusIDChanging(long value);
        partial void OnStatusIDChanged();
        /// <summary>
        /// There are no comments for Property Text in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this.OnTextChanging(value);
                this.ReportPropertyChanging("Text");
                this._Text = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Text");
                this.OnTextChanged();
            }
        }
        private string _Text;
        partial void OnTextChanging(string value);
        partial void OnTextChanged();
        /// <summary>
        /// There are no comments for Property Latitude in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<double> Latitude
        {
            get
            {
                return this._Latitude;
            }
            set
            {
                this.OnLatitudeChanging(value);
                this.ReportPropertyChanging("Latitude");
                this._Latitude = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Latitude");
                this.OnLatitudeChanged();
            }
        }
        private global::System.Nullable<double> _Latitude;
        partial void OnLatitudeChanging(global::System.Nullable<double> value);
        partial void OnLatitudeChanged();
        /// <summary>
        /// There are no comments for Property Longtitude in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<double> Longtitude
        {
            get
            {
                return this._Longtitude;
            }
            set
            {
                this.OnLongtitudeChanging(value);
                this.ReportPropertyChanging("Longtitude");
                this._Longtitude = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Longtitude");
                this.OnLongtitudeChanged();
            }
        }
        private global::System.Nullable<double> _Longtitude;
        partial void OnLongtitudeChanging(global::System.Nullable<double> value);
        partial void OnLongtitudeChanged();
        /// <summary>
        /// There are no comments for Property Url in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this.OnUrlChanging(value);
                this.ReportPropertyChanging("Url");
                this._Url = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Url");
                this.OnUrlChanged();
            }
        }
        private string _Url;
        partial void OnUrlChanging(string value);
        partial void OnUrlChanged();
        /// <summary>
        /// There are no comments for Property GeoUrl in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string GeoUrl
        {
            get
            {
                return this._GeoUrl;
            }
            set
            {
                this.OnGeoUrlChanging(value);
                this.ReportPropertyChanging("GeoUrl");
                this._GeoUrl = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("GeoUrl");
                this.OnGeoUrlChanged();
            }
        }
        private string _GeoUrl;
        partial void OnGeoUrlChanging(string value);
        partial void OnGeoUrlChanged();
        /// <summary>
        /// There are no comments for Property CreateDT in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.DateTime CreateDT
        {
            get
            {
                return this._CreateDT;
            }
            set
            {
                this.OnCreateDTChanging(value);
                this.ReportPropertyChanging("CreateDT");
                this._CreateDT = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("CreateDT");
                this.OnCreateDTChanged();
            }
        }
        private global::System.DateTime _CreateDT;
        partial void OnCreateDTChanging(global::System.DateTime value);
        partial void OnCreateDTChanged();
        /// <summary>
        /// There are no comments for Property ID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Guid ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this.OnIDChanging(value);
                this.ReportPropertyChanging("ID");
                this._ID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ID");
                this.OnIDChanged();
            }
        }
        private global::System.Guid _ID;
        partial void OnIDChanging(global::System.Guid value);
        partial void OnIDChanged();
    }
}
