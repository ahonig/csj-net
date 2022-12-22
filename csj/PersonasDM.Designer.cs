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
// Generation date: 04/10/2022 22:38:10
namespace csj
{
    
    /// <summary>
    /// There are no comments for csjEntityPersona in the schema.
    /// </summary>
    public partial class csjEntityPersona : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new csjEntityPersona object using the connection string found in the 'csjEntityPersona' section of the application configuration file.
        /// </summary>
        public csjEntityPersona() : 
                base("name=csjEntityPersona", "csjEntityPersona")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new csjEntityPersona object.
        /// </summary>
        public csjEntityPersona(string connectionString) : 
                base(connectionString, "csjEntityPersona")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new csjEntityPersona object.
        /// </summary>
        public csjEntityPersona(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "csjEntityPersona")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for persona in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<persona> persona
        {
            get
            {
                if ((this._persona == null))
                {
                    this._persona = base.CreateQuery<persona>("[persona]");
                }
                return this._persona;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<persona> _persona;
        /// <summary>
        /// There are no comments for persona in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddTopersona(persona persona)
        {
            base.AddObject("persona", persona);
        }
    }
    /// <summary>
    /// There are no comments for csjPersonaModel.persona in the schema.
    /// </summary>
    /// <KeyProperties>
    /// persona_id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="csjPersonaModel", Name="persona")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class persona : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new persona object.
        /// </summary>
        /// <param name="persona_id">Initial value of persona_id.</param>
        /// <param name="nombres">Initial value of nombres.</param>
        /// <param name="apellidos">Initial value of apellidos.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static persona Createpersona(int persona_id, string nombres, string apellidos)
        {
            persona persona = new persona();
            persona.persona_id = persona_id;
            persona.nombres = nombres;
            persona.apellidos = apellidos;
            return persona;
        }
        /// <summary>
        /// There are no comments for property persona_id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
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
        /// There are no comments for property documento_tipo_id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Nullable<short> documento_tipo_id
        {
            get
            {
                return this._documento_tipo_id;
            }
            set
            {
                this.Ondocumento_tipo_idChanging(value);
                this.ReportPropertyChanging("documento_tipo_id");
                this._documento_tipo_id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("documento_tipo_id");
                this.Ondocumento_tipo_idChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Nullable<short> _documento_tipo_id;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Ondocumento_tipo_idChanging(global::System.Nullable<short> value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Ondocumento_tipo_idChanged();
        /// <summary>
        /// There are no comments for property documento_nro in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string documento_nro
        {
            get
            {
                return this._documento_nro;
            }
            set
            {
                this.Ondocumento_nroChanging(value);
                this.ReportPropertyChanging("documento_nro");
                this._documento_nro = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("documento_nro");
                this.Ondocumento_nroChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _documento_nro;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Ondocumento_nroChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void Ondocumento_nroChanged();
        /// <summary>
        /// There are no comments for property nombres in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string nombres
        {
            get
            {
                return this._nombres;
            }
            set
            {
                this.OnnombresChanging(value);
                this.ReportPropertyChanging("nombres");
                this._nombres = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("nombres");
                this.OnnombresChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _nombres;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnnombresChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnnombresChanged();
        /// <summary>
        /// There are no comments for property apellidos in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string apellidos
        {
            get
            {
                return this._apellidos;
            }
            set
            {
                this.OnapellidosChanging(value);
                this.ReportPropertyChanging("apellidos");
                this._apellidos = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("apellidos");
                this.OnapellidosChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _apellidos;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnapellidosChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnapellidosChanged();
        /// <summary>
        /// There are no comments for property sexo in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string sexo
        {
            get
            {
                return this._sexo;
            }
            set
            {
                this.OnsexoChanging(value);
                this.ReportPropertyChanging("sexo");
                this._sexo = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("sexo");
                this.OnsexoChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _sexo;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnsexoChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnsexoChanged();
        /// <summary>
        /// There are no comments for property nacimiento in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Nullable<global::System.DateTime> nacimiento
        {
            get
            {
                return this._nacimiento;
            }
            set
            {
                this.OnnacimientoChanging(value);
                this.ReportPropertyChanging("nacimiento");
                this._nacimiento = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("nacimiento");
                this.OnnacimientoChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Nullable<global::System.DateTime> _nacimiento;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnnacimientoChanging(global::System.Nullable<global::System.DateTime> value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnnacimientoChanged();
    }
}