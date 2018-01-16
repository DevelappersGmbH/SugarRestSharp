// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591

namespace SugarRestSharp.Models
{
	using System;
	using Newtonsoft.Json;
	

    /// <summary>
    /// A class which represents the accounts_audit table.
    /// </summary>
	[ModuleProperty(ModuleName = "AccountsAudit", TableName="accounts_audit")]
	public partial class AccountsAudit : EntityBase
	{
		[JsonProperty(PropertyName = "id")]
		public virtual string Id { get; set; }

		[JsonProperty(PropertyName = "parent_id")]
		public virtual string ParentId { get; set; }

		[JsonProperty(PropertyName = "date_created")]
		public virtual DateTime? DateCreated { get; set; }

		[JsonProperty(PropertyName = "created_by")]
		public virtual string CreatedBy { get; set; }

		[JsonProperty(PropertyName = "field_name")]
		public virtual string FieldName { get; set; }

		[JsonProperty(PropertyName = "data_type")]
		public virtual string DataType { get; set; }

		[JsonProperty(PropertyName = "before_value_string")]
		public virtual string BeforeValueString { get; set; }

		[JsonProperty(PropertyName = "after_value_string")]
		public virtual string AfterValueString { get; set; }

		[JsonProperty(PropertyName = "before_value_text")]
		public virtual string BeforeValueText { get; set; }

		[JsonProperty(PropertyName = "after_value_text")]
		public virtual string AfterValueText { get; set; }

	}
}