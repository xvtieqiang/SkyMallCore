﻿using SkyMallCore.Core;
using SkyMallCore.Models;
using SkyMallCore.Respository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkyMallCore.Services
{
    public class LinkService : ILinkService
    {
        ISysLogRespository _LogRespository;
        ILinkRespository _Respository;
        ISysModuleService _SysModuleService;
        ISysModuleButtonService _SysModuleButtonService;

        public LinkService(ISysLogRespository sysLogRespository, ILinkRespository LinkRespository,
            ISysModuleService sysModuleService,
        ISysModuleButtonService sysModuleButtonService
            )
        {
            _LogRespository = sysLogRespository;
            _Respository = LinkRespository;
            _SysModuleService = sysModuleService;
            _SysModuleButtonService = sysModuleButtonService;
        }



        public List<Link> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<Link>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.LinkName.Contains(keyword));
            }
            return _Respository.Get(expression).OrderBy(t => t.SortCode).ToList();
        }

        public Link GetForm(string keyValue)
        {
            return _Respository.Get(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            _Respository.Delete(keyValue);
        }
        public void SubmitForm(Link Link, string[] permissionIds, string keyValue)
        {
            //if (!string.IsNullOrEmpty(keyValue))
            //{
            //    Link.Id = keyValue;
            //}
            //else
            //{
            //    Link.Id = Common.GuId();
            //}
            //var moduledata = _SysModuleService.GetList();
            //var buttondata = _SysModuleButtonService.GetList();
            //List<LinkAuthorize> LinkAuthorizes = new List<LinkAuthorize>();
            //foreach (var itemId in permissionIds)
            //{
            //    LinkAuthorize LinkAuthorize = new LinkAuthorize();
            //    LinkAuthorize.Id = Common.GuId();
            //    LinkAuthorize.ObjectType = 1;
            //    LinkAuthorize.ObjectId = Link.Id;
            //    LinkAuthorize.ItemId = itemId;
            //    if (moduledata.Find(t => t.Id == itemId) != null)
            //    {
            //        LinkAuthorize.ItemType = 1;
            //    }
            //    if (buttondata.Find(t => t.Id == itemId) != null)
            //    {
            //        LinkAuthorize.ItemType = 2;
            //    }
            //    LinkAuthorizes.Add(LinkAuthorize);
            //}
            //_Respository.SubmitForm(Link, LinkAuthorizes, keyValue);
        }


        public void SubmitForm(Link roleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.Id = keyValue;
                _Respository.Update(roleEntity);
            }
            else
            {
                //roleEntity.Category = 2;
                _Respository.Insert(roleEntity);
            }
        }


    }


}
