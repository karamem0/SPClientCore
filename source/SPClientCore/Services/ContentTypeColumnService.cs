//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface IContentTypeColumnService
    {

        ContentTypeColumn CreateObject(ContentType contentTypeObject, IReadOnlyDictionary<string, object> creationInformation, bool pushChanges);

        ContentTypeColumn GetObject(ContentTypeColumn contentTypeColumnObject);

        ContentTypeColumn GetObject(ContentType contentTypeObject, Guid columnId);

        IEnumerable<ContentTypeColumn> GetObjectEnumerable(ContentType contentTypeObject);

        void UpdateObject(ContentType contentTypeObject, ContentTypeColumn contentTypeColumnObject, IReadOnlyDictionary<string, object> modificationInformation, bool pushChanges);

        void RemoveObject(ContentType contentTypeObject, ContentTypeColumn contentTypeColumnObject, bool pushChanges);

    }

    public class ContentTypeColumnService : ClientService<ContentTypeColumn>, IContentTypeColumnService
    {

        public ContentTypeColumnService(ClientContext clientContext) : base(clientContext)
        {
        }

        public ContentTypeColumn CreateObject(ContentType contentTypeObject, IReadOnlyDictionary<string, object> creationInformation, bool pushChanges)
        {
            if (contentTypeObject == null)
            {
                throw new ArgumentNullException(nameof(contentTypeObject));
            }
            if (creationInformation == null)
            {
                throw new ArgumentNullException(nameof(creationInformation));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(contentTypeObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "FieldLinks"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "Add",
                    requestPayload.CreateParameter(new ContentTypeColumnCreationInformation(creationInformation))),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(ContentTypeColumn))
                });
            var objectPath4 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Update",
                    requestPayload.CreateParameter(pushChanges)));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ContentTypeColumn>(requestPayload.ActionQueryId);
        }

        public ContentTypeColumn GetObject(ContentType contentTypeObject, Guid columnId)
        {
            if (contentTypeObject == null)
            {
                throw new ArgumentNullException(nameof(contentTypeObject));
            }
            if (columnId == null)
            {
                throw new ArgumentNullException(nameof(columnId));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(contentTypeObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "FieldLinks"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetById",
                    requestPayload.CreateParameter(columnId)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(ContentTypeColumn))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ContentTypeColumn>(requestPayload.ActionQueryId);
        }

        public IEnumerable<ContentTypeColumn> GetObjectEnumerable(ContentType contentTypeObject)
        {
            if (contentTypeObject == null)
            {
                throw new ArgumentNullException(nameof(contentTypeObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(contentTypeObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "FieldLinks"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(ContentTypeColumn))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ContentTypeColumnEnumerable>(requestPayload.ActionQueryId);
        }

        public void UpdateObject(ContentType contentTypeObject, ContentTypeColumn contentTypeColumnObject, IReadOnlyDictionary<string, object> modificationInformation, bool pushChanges)
        {
            if (contentTypeObject == null)
            {
                throw new ArgumentNullException(nameof(contentTypeObject));
            }
            if (contentTypeColumnObject == null)
            {
                throw new ArgumentNullException(nameof(contentTypeColumnObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(contentTypeObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathIdentity(contentTypeColumnObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                objectPath2,
                requestPayload.CreateSetPropertyDelegates(contentTypeColumnObject, modificationInformation).ToArray());
            var objectPath4 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Update",
                    requestPayload.CreateParameter(pushChanges)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void RemoveObject(ContentType contentTypeObject, ContentTypeColumn contentTypeColumnObject, bool pushChanges)
        {
            if (contentTypeObject == null)
            {
                throw new ArgumentNullException(nameof(contentTypeObject));
            }
            if (contentTypeColumnObject == null)
            {
                throw new ArgumentNullException(nameof(contentTypeColumnObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(contentTypeObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathIdentity(contentTypeColumnObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                objectPath2,
                objectPathId => new ClientActionMethod(objectPathId, "DeleteObject"));
            var objectPath4 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Update",
                    requestPayload.CreateParameter(pushChanges)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}