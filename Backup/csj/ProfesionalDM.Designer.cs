﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.8813
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Nombre de archivo original:
// Fecha de generación: 11/07/2022 18:53:01
namespace csj
{
    
    /// <summary>
    /// No hay ningún comentario para csjEntityProfesional en el esquema.
    /// </summary>
    public partial class csjEntityProfesional : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Inicializa un nuevo objeto csjEntityProfesional usando la cadena de conexión encontrada en la sección 'csjEntityProfesional' del archivo de configuración de la aplicación.
        /// </summary>
        public csjEntityProfesional() : 
                base("name=csjEntityProfesional", "csjEntityProfesional")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Inicializar un nuevo objeto csjEntityProfesional.
        /// </summary>
        public csjEntityProfesional(string connectionString) : 
                base(connectionString, "csjEntityProfesional")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Inicializar un nuevo objeto csjEntityProfesional.
        /// </summary>
        public csjEntityProfesional(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "csjEntityProfesional")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// No hay ningún comentario para profesional en el esquema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<profesional> profesional
        {
            get
            {
                if ((this._profesional == null))
                {
                    this._profesional = base.CreateQuery<profesional>("[profesional]");
                }
                return this._profesional;
            }
        }
        private global::System.Data.Objects.ObjectQuery<profesional> _profesional;
        /// <summary>
        /// No hay ningún comentario para profesional en el esquema.
        /// </summary>
        public void AddToprofesional(profesional profesional)
        {
            base.AddObject("profesional", profesional);
        }
    }
    /// <summary>
    /// No hay ningún comentario para csjProfesionalModel.profesional en el esquema.
    /// </summary>
    /// <KeyProperties>
    /// persona_id
    /// profesional_tipo_id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="csjProfesionalModel", Name="profesional")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class profesional : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Crear un nuevo objeto profesional.
        /// </summary>
        /// <param name="persona_id">Valor inicial de persona_id.</param>
        /// <param name="profesional_tipo_id">Valor inicial de profesional_tipo_id.</param>
        /// <param name="matricula_nro">Valor inicial de matricula_nro.</param>
        public static profesional Createprofesional(int persona_id, short profesional_tipo_id, string matricula_nro)
        {
            profesional profesional = new profesional();
            profesional.persona_id = persona_id;
            profesional.profesional_tipo_id = profesional_tipo_id;
            profesional.matricula_nro = matricula_nro;
            return profesional;
        }
        /// <summary>
        /// No hay ningún comentario para la propiedad persona_id en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
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
        private int _persona_id;
        partial void Onpersona_idChanging(int value);
        partial void Onpersona_idChanged();
        /// <summary>
        /// No hay ningún comentario para la propiedad profesional_tipo_id en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
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
        private short _profesional_tipo_id;
        partial void Onprofesional_tipo_idChanging(short value);
        partial void Onprofesional_tipo_idChanged();
        /// <summary>
        /// No hay ningún comentario para la propiedad matricula_nro en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string matricula_nro
        {
            get
            {
                return this._matricula_nro;
            }
            set
            {
                this.Onmatricula_nroChanging(value);
                this.ReportPropertyChanging("matricula_nro");
                this._matricula_nro = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("matricula_nro");
                this.Onmatricula_nroChanged();
            }
        }
        private string _matricula_nro;
        partial void Onmatricula_nroChanging(string value);
        partial void Onmatricula_nroChanged();
        /// <summary>
        /// No hay ningún comentario para la propiedad matricula_fecha_expedicion en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> matricula_fecha_expedicion
        {
            get
            {
                return this._matricula_fecha_expedicion;
            }
            set
            {
                this.Onmatricula_fecha_expedicionChanging(value);
                this.ReportPropertyChanging("matricula_fecha_expedicion");
                this._matricula_fecha_expedicion = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("matricula_fecha_expedicion");
                this.Onmatricula_fecha_expedicionChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _matricula_fecha_expedicion;
        partial void Onmatricula_fecha_expedicionChanging(global::System.Nullable<global::System.DateTime> value);
        partial void Onmatricula_fecha_expedicionChanged();
        /// <summary>
        /// No hay ningún comentario para la propiedad juramento_acta_nro en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> juramento_acta_nro
        {
            get
            {
                return this._juramento_acta_nro;
            }
            set
            {
                this.Onjuramento_acta_nroChanging(value);
                this.ReportPropertyChanging("juramento_acta_nro");
                this._juramento_acta_nro = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("juramento_acta_nro");
                this.Onjuramento_acta_nroChanged();
            }
        }
        private global::System.Nullable<int> _juramento_acta_nro;
        partial void Onjuramento_acta_nroChanging(global::System.Nullable<int> value);
        partial void Onjuramento_acta_nroChanged();
        /// <summary>
        /// No hay ningún comentario para la propiedad juramento_fecha en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> juramento_fecha
        {
            get
            {
                return this._juramento_fecha;
            }
            set
            {
                this.Onjuramento_fechaChanging(value);
                this.ReportPropertyChanging("juramento_fecha");
                this._juramento_fecha = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("juramento_fecha");
                this.Onjuramento_fechaChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _juramento_fecha;
        partial void Onjuramento_fechaChanging(global::System.Nullable<global::System.DateTime> value);
        partial void Onjuramento_fechaChanged();
        /// <summary>
        /// No hay ningún comentario para la propiedad habilitado en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<bool> habilitado
        {
            get
            {
                return this._habilitado;
            }
            set
            {
                this.OnhabilitadoChanging(value);
                this.ReportPropertyChanging("habilitado");
                this._habilitado = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("habilitado");
                this.OnhabilitadoChanged();
            }
        }
        private global::System.Nullable<bool> _habilitado;
        partial void OnhabilitadoChanging(global::System.Nullable<bool> value);
        partial void OnhabilitadoChanged();
        /// <summary>
        /// No hay ningún comentario para la propiedad universidad en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string universidad
        {
            get
            {
                return this._universidad;
            }
            set
            {
                this.OnuniversidadChanging(value);
                this.ReportPropertyChanging("universidad");
                this._universidad = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("universidad");
                this.OnuniversidadChanged();
            }
        }
        private string _universidad;
        partial void OnuniversidadChanging(string value);
        partial void OnuniversidadChanged();
        /// <summary>
        /// No hay ningún comentario para la propiedad egreso_anyo en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<short> egreso_anyo
        {
            get
            {
                return this._egreso_anyo;
            }
            set
            {
                this.Onegreso_anyoChanging(value);
                this.ReportPropertyChanging("egreso_anyo");
                this._egreso_anyo = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("egreso_anyo");
                this.Onegreso_anyoChanged();
            }
        }
        private global::System.Nullable<short> _egreso_anyo;
        partial void Onegreso_anyoChanging(global::System.Nullable<short> value);
        partial void Onegreso_anyoChanged();
        /// <summary>
        /// No hay ningún comentario para la propiedad antecedente_penal en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string antecedente_penal
        {
            get
            {
                return this._antecedente_penal;
            }
            set
            {
                this.Onantecedente_penalChanging(value);
                this.ReportPropertyChanging("antecedente_penal");
                this._antecedente_penal = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("antecedente_penal");
                this.Onantecedente_penalChanged();
            }
        }
        private string _antecedente_penal;
        partial void Onantecedente_penalChanging(string value);
        partial void Onantecedente_penalChanged();
    }
}
