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

    [ClientObject(Name = "SP.FieldMultiChoice", Id = "84c160f-3783-4344-a471-80e032719f26")]
    [JsonObject()]
    public class ColumnMultiChoice : Column
    {

        public ColumnMultiChoice()
        {
        }

        [JsonProperty()]
        public override bool AutoIndexed { get; protected set; }

        [JsonProperty()]
        public override bool CanBeDeleted { get; protected set; }

        [JsonProperty()]
        public override string ClientSideComponentId { get; protected set; }

        [JsonProperty()]
        public override string ClientSideComponentProperties { get; protected set; }

        [JsonProperty()]
        public virtual IReadOnlyCollection<Column> Columns { get; protected set; }

        [JsonProperty("FieldTypeKind")]
        public override ColumnType ColumnType { get; protected set; }

        [JsonProperty()]
        public override string CustomFormatter { get; protected set; }

        [JsonProperty()]
        public override string DefaultFormula { get; protected set; }

        [JsonProperty()]
        public override string DefaultValue { get; protected set; }

        [JsonProperty()]
        public override string Description { get; protected set; }

        [JsonProperty()]
        public override string Direction { get; protected set; }

        [JsonProperty()]
        public override bool EnforceUniqueValues { get; protected set; }

        [JsonProperty()]
        public override string EntityPropertyName { get; protected set; }

        [JsonProperty()]
        public virtual bool FillInChoice { get; protected set; }

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
        public override string JSLink { get; protected set; }

        [JsonProperty()]
        public virtual string Mappings { get; protected set; }

        [JsonProperty("InternalName")]
        public override string Name { get; protected set; }

        [JsonProperty()]
        public override bool NoCrawl { get; protected set; }

        [JsonProperty()]
        public override bool PinnedToFiltersPane { get; protected set; }

        [JsonProperty("ReadOnlyField")]
        public override bool ReadOnly { get; protected set; }

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
        public override string ValidationFormula { get; protected set; }

        [JsonProperty()]
        public override string ValidationMessage { get; protected set; }

    }

}
