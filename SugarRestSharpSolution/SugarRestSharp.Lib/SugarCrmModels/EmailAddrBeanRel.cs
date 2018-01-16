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
    /// A class which represents the email_addr_bean_rel table.
    /// </summary>
	[ModuleProperty(ModuleName = "EmailAddrBeanRel", TableName="email_addr_bean_rel")]
	public partial class EmailAddrBeanRel : EntityBase
	{
		[JsonProperty(PropertyName = "id")]
		public virtual string Id { get; set; }

		[JsonProperty(PropertyName = "email_address_id")]
		public virtual string EmailAddressId { get; set; }

		[JsonProperty(PropertyName = "bean_id")]
		public virtual string BeanId { get; set; }

		[JsonProperty(PropertyName = "bean_module")]
		public virtual string BeanModule { get; set; }

		[JsonProperty(PropertyName = "primary_address")]
		public virtual sbyte? PrimaryAddress { get; set; }

		[JsonProperty(PropertyName = "reply_to_address")]
		public virtual sbyte? ReplyToAddress { get; set; }

		[JsonProperty(PropertyName = "date_created")]
		public virtual DateTime? DateCreated { get; set; }

		[JsonProperty(PropertyName = "date_modified")]
		public virtual DateTime? DateModified { get; set; }

		[JsonProperty(PropertyName = "deleted")]
		public virtual sbyte? Deleted { get; set; }

	}
}