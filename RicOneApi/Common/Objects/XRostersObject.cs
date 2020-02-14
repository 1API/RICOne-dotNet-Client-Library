﻿using RestSharp;
using RicOneApi.Common.Rest;
using RicOneApi.Models.XPress;

/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.7.0
 * Since       2019-01-03
 */
namespace RicOneApi.Common.Objects
{
    /// <summary>
    /// xRosters Service Paths.
    /// </summary>
    class XRostersObject
    {
        private RestClient rc;
        private string baseApiUrl;

        /// <summary>
        /// XRosters Object Constructor.
        /// </summary>
        /// <param name="rc">REST client.</param>
        /// <param name="baseApiUrl">Base API URL.</param>
        internal XRostersObject(RestClient rc, string baseApiUrl)
        {
            this.rc = rc;
            this.baseApiUrl = baseApiUrl;
        }

        /// <summary>
        /// Request all xRosters.
        /// </summary>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRosters()
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRosters, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters by school year.
        /// </summary>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRosters(int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRosters, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters with paging.
        /// </summary>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRosters(int? navigationPage, int? navigationPageSize)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRosters, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters with paging by school year.
        /// </summary>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRosters(int? navigationPage, int? navigationPageSize, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize, schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRosters, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point.
        /// </summary>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRosters(string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRosters, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point with paging.
        /// </summary>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRosters(int? navigationPage, int? navigationPageSize, string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRosters, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request single xRoster by refId.
        /// </summary>
        /// <param name="refId">RefId of xRoster.</param>
        /// <returns>Single xRosters type.</returns>
        internal ResponseSingle<XRosterType> GetXRoster(string refId)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRosterByRefId, refId, rh, rqp);
            return rr.MakeSingleRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request single xRoster by refId by school year.
        /// </summary>
        /// <param name="refId">RefId of xRoster.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>Single xRosters type</returns>
        internal ResponseSingle<XRosterType> GetXRoster(string refId, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRosterByRefId, refId, rh, rqp);
            return rr.MakeSingleRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xLea by refId.
        /// </summary>
        /// <param name="refId">RefId of xLea.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXLea(string refId)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXLea, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xLea by refId by school year.
        /// </summary>
        /// <param name="refId">RefId of xLea.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXLea(string refId, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXLea, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xLea by refId with paging.
        /// </summary>
        /// <param name="refId">RefId of xLea.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXLea(string refId, int? navigationPage, int? navigationPageSize)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXLea, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xLea by refId with paging by school year.
        /// </summary>
        /// <param name="refId">RefId of xLea.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXLea(string refId, int? navigationPage, int? navigationPageSize, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize, schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXLea, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point by a specific xLea.
        /// </summary>
        /// <param name="refId">RefId of xLea.</param>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXLea(string refId, string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXLea, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point by a specific xLea with paging.
        /// </summary>
        /// <param name="refId">RefId of xLea.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXLea(string refId, int? navigationPage, int? navigationPageSize, string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXLea, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xSchool by refId.
        /// </summary>
        /// <param name="refId">RefId of xSchool.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXSchool(string refId)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXSchool, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xSchool by refId by school year.
        /// </summary>
        /// <param name="refId">RefId of xSchool.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXSchool(string refId, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXSchool, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xSchool by refId with paging.
        /// </summary>
        /// <param name="refId">RefId of xSchool.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXSchool(string refId, int? navigationPage, int? navigationPageSize)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXSchool, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xSchool by refId with paging by school year.
        /// </summary>
        /// <param name="refId">RefId of xSchool.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXSchool(string refId, int? navigationPage, int? navigationPageSize, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize, schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXSchool, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point by a specific xSchool.
        /// </summary>
        /// <param name="refId">RefId of xSchool.</param>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXSchool(string refId, string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXSchool, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point by a specific xSchool with paging.
        /// </summary>
        /// <param name="refId">RefId of xSchool.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXSchool(string refId, int? navigationPage, int? navigationPageSize, string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXSchool, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xCourse by refId.
        /// </summary>
        /// <param name="refId">RefId of xCourse.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXCourse(string refId)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXCourse, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xCourse by refId by school year.
        /// </summary>
        /// <param name="refId">RefId of xCourse.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXCourse(string refId, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXCourse, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xCourse by refId with paging.
        /// </summary>
        /// <param name="refId">RefId of xCourse.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXCourse(string refId, int? navigationPage, int? navigationPageSize)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXCourse, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xCourse by refId with paging by school year.
        /// </summary>
        /// <param name="refId">RefId of xCourse.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXCourse(string refId, int? navigationPage, int? navigationPageSize, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize, schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXCourse, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point by a specific xCourse.
        /// </summary>
        /// <param name="refId">RefId of xCourse.</param>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXCourse(string refId, string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXCourse, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point by a specific xCourse with paging.
        /// </summary>
        /// <param name="refId">RefId of xCourse.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXCourse(string refId, int? navigationPage, int? navigationPageSize, string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXCourse, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xStaff by refId.
        /// </summary>
        /// <param name="refId">RefId of xStaff.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStaff(string refId)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStaff, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xStaff by refId by school year.
        /// </summary>
        /// <param name="refId">RefId of xStaff.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStaff(string refId, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStaff, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xStaff by refId with paging.
        /// </summary>
        /// <param name="refId">RefId of xStaff.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStaff(string refId, int? navigationPage, int? navigationPageSize)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStaff, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xStaff by refId with paging by school year.
        /// </summary>
        /// <param name="refId">RefId of xStaff.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStaff(string refId, int? navigationPage, int? navigationPageSize, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize, schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStaff, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point by a specific xStaff.
        /// </summary>
        /// <param name="refId">RefId of xStaff.</param>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStaff(string refId, string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStaff, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point by a specific xStaff with paging.
        /// </summary>
        /// <param name="refId">RefId of xStaff.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStaff(string refId, int? navigationPage, int? navigationPageSize, string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStaff, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xStudent by refId.
        /// </summary>
        /// <param name="refId">RefId of xStudent.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStudent(string refId)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStudent, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xStudent by refId by school year.
        /// </summary>
        /// <param name="refId">RefId of xStudent.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStudent(string refId, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStudent, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xStudent by refId with paging.
        /// </summary>
        /// <param name="refId">RefId of xStudent.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStudent(string refId, int? navigationPage, int? navigationPageSize)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStudent, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request xRosters associated to a specific xStudent by refId with paging by school year.
        /// </summary>
        /// <param name="refId">RefId of xStudent.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="schoolYear">The year of the requested data (i.e. 2018 for the 2017-2018 school year).</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStudent(string refId, int? navigationPage, int? navigationPageSize, int? schoolYear)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize, schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStudent, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point by a specific xStudent.
        /// </summary>
        /// <param name="refId">RefId of xStudent.</param>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStudent(string refId, string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStudent, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }

        /// <summary>
        /// Request all xRosters value changes from a given point by a specific xStudent with paging.
        /// </summary>
        /// <param name="refId">RefId of xStudent.</param>
        /// <param name="navigationPage">Page to retrieve.</param>
        /// <param name="navigationPageSize">Number of resources to retrieve.</param>
        /// <param name="opaqueMarker">Uses an ISO8601 timestamp that indicates a point since the last changes have been requested.</param>
        /// <returns>List of xRosters type.</returns>
        internal ResponseMulti<XRosterType> GetXRostersByXStudent(string refId, int? navigationPage, int? navigationPageSize, string opaqueMarker)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(baseApiUrl, ServicePath.GetXRostersByXStudent, refId, rh, rqp);
            return rr.MakeAllRequest<XRosterType, XRosterCollectionType>(rc, rp);
        }
    }
}
