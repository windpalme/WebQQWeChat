﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using WebWeChat.Im.Bean;
using WebWeChat.Im.Core;
using WebWeChat.Util;

namespace WebWeChat.Im.Module.Impl
{
    public class StoreModule : WeChatModule
    {
        /// <summary>
        /// 联系人总数
        /// </summary>
        public int MemberCount { get; set; }

        /// <summary>
        /// 存放联系人
        /// 主键是member的username
        /// </summary>
        public ConcurrentDictionary<string, ContactMember> ContactMemberDic { get; set; } = new ConcurrentDictionary<string, ContactMember>();
        
        /// <summary>
        /// 特殊账号
        /// </summary>
        public IEnumerable<ContactMember> SpecialUsers => ContactMemberDic.Values.Where(m => m.IsSpecialUser());

        public int SpecialUserCount => SpecialUsers.Count();

        /// <summary>
        /// 群
        /// </summary>
        public IEnumerable<ContactMember> Groups => ContactMemberDic.Values.Where(m => m.IsGroup());

        public int GroupCount => Groups.Count();

        /// <summary>
        /// 好友
        /// </summary>
        public IEnumerable<ContactMember> Friends => ContactMemberDic.Values.Where(m => !m.IsSpecialUser() && !m.IsGroup() && !m.IsPublicUsers());

        public int FriendCount => Friends.Count();

        /// <summary>
        /// 公众号/服务号
        /// </summary>
        public IEnumerable<ContactMember> PublicUsers => ContactMemberDic.Values.Where(m => m.IsPublicUsers());

        public int PublicUserCount => PublicUsers.Count();

        public StoreModule(IWeChatContext context) : base(context)
        {
        }
    }
}
