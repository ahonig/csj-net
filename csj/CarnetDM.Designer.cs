﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 04/10/2022 22:38:08
namespace csj
{
    
    /// <summary>
    /// There are no comments for csjEntityCarnet in the schema.
    /// </summary>
    public partial class csjEntityCarnet : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new csjEntityCarnet object using the connection string found in the 'csjEntityCarnet' section of the application configuration file.
        /// </summary>
        public csjEntityCarnet() : 
                base("name=csjEntityCarnet", "csjEntityCarnet")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new csjEntityCarnet object.
        /// </summary>
        public csjEntityCarnet(string connectionString) : 
                base(connectionString, "csjEntityCarnet")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new csjEntityCarnet object.
        /// </summary>
        public csjEntityCarnet(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "csjEntityCarnet")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for carnet in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<carnet> carnet
        {
            get
            {
                if ((this._carnet == null))
                {
                    this._carnet = base.CreateQuery<carnet>("[carnet]");
                }
                return this._carnet;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<carnet> _carnet;
        /// <summary>
        /// There are no comments for carnet in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddTocarnet(carnet carnet)
        {
            base.AddObject("carnet", carnet);
        }
    }
    /// <summary>
    /// There are no comments for csjCarnetModel.carnet in the schema.
    /// </summary>
    /// <KeyProperties>
    /// carnet_qr
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="csjCarnetModel", Name="carnet")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class carnet : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new carnet object.
        /// </summary>
        /// <param name="carnet_qr">Initial value of carnet_qr.</param>
        /// <param name="persona_id">Initial value of persona_id.</param>
        /// <param name="profesional_tipo_id">Initial value of profesional_tipo_id.</param>
        /// <param name="impreso">Initial value of impreso.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static carnet Createcarnet(string carnet_qr, int persona_id, short profesional_tipo_id, bool impreso)
        {
            carnet carnet = new carnet();
            carnet.carnet_qr = carnet_qr;
            carnet.persona_id = persona_id;
            carnet.profesional_tipo_id = profesional_tipo_id;
            carnet.impreso = impreso;
            return carnet;
        }
        /// <summary>
        /// There are no comments for property carnet_qr in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string carnet_qr
        {
            get
            {
                return this._carnet_qr;
            }
            set
            {
                this.Oncarnet_qrChanging(value);
                this.ReportPropertyChanging("carnet_qr");
                this._carnet_qr = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("carnet_qr");
                this.Oncarnet_qrChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _carnet_qr;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Oncarnet_qrChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Oncarnet_qrChanged();
        /// <summary>
        /// There are no comments for property persona_id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int persona_id
        {
            get
            {
                return this._persona_id;
            }
            set
            {
                this.Onpersona_idChanging(value);
                this.ReportPropertyChanging("persona_id");
                this._persona_id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("persona_id");
                this.Onpersona_idChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _persona_id;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onpersona_idChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onpersona_idChanged();
        /// <summary>
        /// There are no comments for property profesional_tipo_id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public short profesional_tipo_id
        {
            get
            {
                return this._profesional_tipo_id;
            }
            set
            {
                this.Onprofesional_tipo_idChanging(value);
                this.ReportPropertyChanging("profesional_tipo_id");
                this._profesional_tipo_id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("profesional_tipo_id");
                this.Onprofesional_tipo_idChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private short _profesional_tipo_id;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onprofesional_tipo_idChanging(short value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onprofesional_tipo_idChanged();
        /// <summary>
        /// There are no comments for property impreso in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool impreso
        {
            get
            {
                return this._impreso;
            }
            set
            {
                this.OnimpresoChanging(value);
                this.ReportPropertyChanging("impreso");
                this._impreso = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("impreso");
                this.OnimpresoChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _impreso;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnimpresoChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnimpresoChanged();
        /// <summary>
        /// There are no comments for property turno_id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Nullable<int> turno_id
        {
            get
            {
                return this._turno_id;
            }
            set
            {
                this.Onturno_idChanging(value);
                this.ReportPropertyChanging("turno_id");
                this._turno_id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("turno_id");
                this.Onturno_idChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Nullable<int> _turno_id;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onturno_idChanging(global::System.Nullable<int> value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onturno_idChanged();
        /// <summary>
        /// There are no comments for property fecha_expedicion in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Nullable<global::System.DateTime> fecha_expedicion
        {
            get
            {
                return this._fecha_expedicion;
            }
            set
            {
                this.Onfecha_expedicionChanging(value);
                this.ReportPropertyChanging("fecha_expedicion");
                this._fecha_expedicion = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("fecha_expedicion");
                this.Onfecha_expedicionChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Nullable<global::System.DateTime> _fecha_expedicion;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onfecha_expedicionChanging(global::System.Nullable<global::System.DateTime> value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onfecha_expedicionChanged();
        /// <summary>
        /// There are no comments for property fecha_vencimiento in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Nullable<global::System.DateTime> fecha_vencimiento
        {
            get
            {
                return this._fecha_vencimiento;
            }
            set
            {
                this.Onfecha_vencimientoChanging(value);
                this.ReportPropertyChanging("fecha_vencimiento");
                this._fecha_vencimiento = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("fecha_vencimiento");
                this.Onfecha_vencimientoChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Nullable<global::System.DateTime> _fecha_vencimiento;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onfecha_vencimientoChanging(global::System.Nullable<global::System.DateTime> value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onfecha_vencimientoChanged();
        /// <summary>
        /// There are no comments for property liquidacion_nro in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string liquidacion_nro
        {
            get
            {
                return this._liquidacion_nro;
            }
            set
            {
                this.Onliquidacion_nroChanging(value);
                this.ReportPropertyChanging("liquidacion_nro");
                this._liquidacion_nro = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("liquidacion_nro");
                this.Onliquidacion_nroChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _liquidacion_nro;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onliquidacion_nroChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Onliquidacion_nroChanged();
    }
}
