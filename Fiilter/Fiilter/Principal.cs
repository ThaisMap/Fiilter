﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiilter
{
    class Principal
    {
        public List<FII> FIIs { get; private set; }

        public Principal()
        {
            scrape();
        }

        private void scrape()
        {
            string page = "https://www.fundsexplorer.com.br/ranking";

            var web = new HtmlWeb();
            var doc = web.Load(page);

            var LinhasResult = doc.DocumentNode.SelectNodes("//tr");
            if (LinhasResult != null)
            {
                foreach (var linha in LinhasResult)
                {
                    var dadosnumericos = linha.SelectNodes(".//td");

                }
            }
        }
    }
}