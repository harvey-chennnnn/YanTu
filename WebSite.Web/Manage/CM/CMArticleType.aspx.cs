﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.CM
{
    public partial class CMArticleType : WebPage
    {
        protected DataTable dataTable = new DataTable();// 创建dataTable对象
        WebSite.CM.DAL.CMArticleType atDAL = new WebSite.CM.DAL.CMArticleType(); //创建商品分类DAL对象
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                BindDataTable();       //绑定商品分类列表信息
            }
        }
        /// <summary>
        /// 绑定dataTable对象方法
        /// </summary>
        private void BindDataTable()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();     //创建查询参数集合
            DataSet dt = atDAL.GetList("", parameters);               //查询所有商品分类信息方法
            dataTable = dt.Tables[0];          //将查询的商品分类信息赋值给dataTable对象
        }

        /// <summary>
        /// 执行DataTable中的查询返回新的DataTable
        /// </summary>
        /// <param name="dt">源数据DataTable</param>
        /// <param name="condition">查询条件</param>
        /// <param name="sortOrder"> </param>
        /// <returns></returns>
        public DataTable GetNewDataTable(DataTable dt, string condition)
        {
            var pagedData = new PagedDataSource();
            var newdt = dt.Clone();
            var dr = dt.Select(condition);
            foreach (var t in dr)
            {
                newdt.ImportRow(t);
            }
            return newdt;//返回的查询结果
        }
        /// <summary>
        /// 通过值显示样式
        /// </summary>
        /// <param name="DisplayCss"></param>
        /// <returns></returns>
        public string GetStyle(string DisplayCss)
        {
            string displayCss = "绿色";
            if (DisplayCss == "绿色")
            {
                displayCss = "<span class=\"label label-success\">绿色</span>";
            }
            else if (DisplayCss == "黄色")
            {
                displayCss = "<span class=\"label label-warning\">黄色</span>";
            }
            else
            {
                displayCss = "<span class=\"label label-important\">红色</span>";
            }
            return displayCss;
        }
    }
}