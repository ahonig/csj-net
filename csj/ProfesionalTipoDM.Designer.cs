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
// Generation date: 04/10/2022 22:38:11
namespace csj
{
    
    /// <summary>
    /// There are no comments for csjEntityProfesionalTipo in the schema.
    /// </summary>
    public partial class csjEntityProfesionalTipo : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new csjEntityProfesionalTipo object using the connection string found in the 'csjEntityProfesionalTipo' section of the application configuration file.
        /// </summary>
        public csjEntityProfesionalTipo() : 
                base("name=csjEntityProfesionalTipo", "csjEntityProfesionalTipo")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new csjEntityProfesionalTipo object.
        /// </summary>
        public csjEntityProfesionalTipo(string connectionString) : 
                base(connectionString, "csjEntityProfesionalTipo")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new csjEntityProfesionalTipo object.
        /// </summary>
        public csjEntityProfesionalTipo(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "csjEntityProfesionalTipo")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for profesional_tipo in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<profesional_tipo> profesional_tipo
        {
            get
            {
                if ((this._profesional_tipo == null))
                {
                    this._profesional_tipo = base.CreateQuery<profesional_tipo>("[profesional_tipo]");
                }
                return this._profesional_tipo;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<profesional_tipo> _profesional_tipo;
        /// <summary>
        /// There are no comments for profesional_tipo in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToprofesional_tipo(profesional_tipo profesional_tipo)
        {
            base.AddObject("profesional_tipo", profesional_tipo);
        }
    }
    /// <summary>
    /// There are no comments for csjProfesionalTipoModel.profesional_tipo in the schema.
    /// </summary>
    /// <KeyProperties>
    /// id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="csjProfesionalTipoModel", Name="profesional_tipo")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class profesional_tipo : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new profesional_tipo object.
        /// </summary>
        /// <param name="id">Initial value of id.</param>
        /// <param name="descripcion">Initial value of descripcion.</param>
        /// <param name="visible">Initial value of visible.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static profesional_tipo Createprofesional_tipo(short id, string descripcion, bool visible)
        {
            profesional_tipo profesional_tipo = new profesional_tipo();
            profesional_tipo.id = id;
            profesional_tipo.descripcion = descripcion;
            profesional_tipo.visible = visible;
            return profesional_tipo;
        }
        /// <summary>
        /// There are no comments for property id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public short id
        {
            get
            {
                return this._id;
            }
            set
            {
                this.OnidChanging(value);
                this.ReportPropertyChanging("id");
                this._id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("id");
                this.OnidChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private short _id;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnidChanging(short value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnidChanged();
        /// <summary>
        /// There are no comments for property descripcion in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string descripcion
        {
            get
            {
                return this._descripcion;
            }
            set
            {
                this.OndescripcionChanging(value);
                this.ReportPropertyChanging("descripcion");
                this._descripcion = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("descripcion");
                this.OndescripcionChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _descripcion;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OndescripcionChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OndescripcionChanged();
        /// <summary>
        /// There are no comments for property visible in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool visible
        {
            get
            {
                return this._visible;
            }
            set
            {
                this.OnvisibleChanging(value);
                this.ReportPropertyChanging("visible");
                this._visible = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("visible");
                this.OnvisibleChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _visible;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnvisibleChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnvisibleChanged();
    }
}
