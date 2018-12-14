//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [ClientObject(Name = "SP.FieldUser", Id = "{ebd2fb89-e8a2-46c4-b317-9b2347121765}")]
    [JsonObject()]
    public class ColumnUser : Column
    {

        public ColumnUser()
        {
        }

        [JsonProperty()]
        public virtual bool AllowDisplay { get; protected set; }

        [JsonProperty()]
        public virtual bool AllowMultipleValues { get; protected set; }

        [JsonProperty()]
        public override bool AutoIndexed { get; protected set; }

        [JsonProperty()]
        public override bool CanBeDeleted { get; protected set; }

        [JsonProperty()]
        public override string ClientSideComponentId { get; protected set; }

        [JsonProperty()]
        public override string ClientSideComponentProperties { get; protected set; }

        [JsonProperty("FieldTypeKind")]
        public override ColumnType ColumnType { get; protected set; }

        [JsonProperty()]
        public override string CustomFormatter { get; protected set; }

        [JsonProperty()]
        public override string DefaultFormula { get; protected set; }

        [JsonProperty()]
        public override string DefaultValue { get; protected set; }

        [JsonProperty()]
        public virtual IReadOnlyCollection<string> DependentLookupInternalNames { get; protected set; }

        [JsonProperty()]
        public override string Description { get; protected set; }

        [JsonProperty()]
        public override string Direction { get; protected set; }

        [JsonProperty()]
        public override bool EnforceUniqueValues { get; protected set; }

        [JsonProperty()]
        public override string EntityPropertyName { get; protected set; }

        [JsonProperty()]
        public override bool Filterable { get; protected set; }

        [JsonProperty()]
        public override bool FromBaseType { get; protected set; }

        [JsonProperty()]
        public override string Group { get; protected set; }

        [JsonProperty()]
        public override bool Hidden { get; protected set; }

        [JsonProperty()]
        public override Guid Id { get; protected set; }

        [JsonProperty()]
        public override bool Indexed { get; protected set; }

        [JsonProperty()]
        public virtual bool IsDependentLookup { get; protected set; }

        [JsonProperty()]
        public virtual bool IsRelationship { get; protected set; }

        [JsonProperty()]
        public override string JSLink { get; protected set; }

        [JsonProperty("LookupField")]
        public virtual string LookupColumnName { get; protected set; }

        [JsonProperty("LookupList")]
        public virtual string LookupListId { get; protected set; }

        [JsonProperty("LookupWebId")]
        public virtual Guid LookupSiteId { get; protected set; }

        [JsonProperty("InternalName")]
        public override string Name { get; protected set; }

        [JsonProperty()]
        public override bool NoCrawl { get; protected set; }

        [JsonProperty()]
        public override bool PinnedToFiltersPane { get; protected set; }

        [JsonProperty()]
        public virtual bool Presence { get; protected set; }

        [JsonProperty("PrimaryFieldId")]
        public virtual string PrimaryColumnId { get; protected set; }

        [JsonProperty("ReadOnlyField")]
        public override bool ReadOnly { get; protected set; }

        [JsonProperty()]
        public virtual RelationshipDeleteBehaviorType RelationshipDeleteBehavior { get; protected set; }

        [JsonProperty()]
        public override bool Required { get; protected set; }

        [JsonProperty()]
        public override string SchemaXml { get; protected set; }

        [JsonProperty()]
        public override string SchemaXmlWithResourceTokens { get; protected set; }

        [JsonProperty()]
        public override string Scope { get; protected set; }

        [JsonProperty()]
        public override bool Sealed { get; protected set; }

        [JsonProperty("SelectionGroup")]
        public virtual int SelectionGroupId { get; protected set; }

        [JsonProperty()]
        public virtual ColumnUserSelectionMode SelectionMode { get; protected set; }

        [JsonProperty()]
        public override bool ShowInFiltersPane { get; protected set; }

        [JsonProperty()]
        public override bool Sortable { get; protected set; }

        [JsonProperty()]
        public override string StaticName { get; protected set; }

        [JsonProperty()]
        public override string Title { get; protected set; }

        [JsonProperty()]
        public override string TypeAsString { get; protected set; }

        [JsonProperty()]
        public override string TypeDisplayName { get; protected set; }

        [JsonProperty()]
        public override string TypeShortDescription { get; protected set; }

        [JsonProperty()]
        public virtual bool UnlimitedLengthInDocumentLibrary { get; protected set; }

        [JsonProperty()]
        public virtual ColumnUrlFormatType UrlFormat { get; protected set; }

        [JsonProperty()]
        public override string ValidationFormula { get; protected set; }

        [JsonProperty()]
        public override string ValidationMessage { get; protected set; }

    }

}