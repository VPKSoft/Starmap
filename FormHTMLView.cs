#region License
/*
Starmap

A 2D star map program.
Copyright © 2017 VPKSoft, Petteri Kautonen

Contact: vpksoft@vpksoft.net

This file is part of Starmap.

Starmap is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Starmap is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Starmap.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPKSoft.LangLib;

namespace SMap
{
    public partial class FormHTMLView : DBLangEngineWinforms
    {
        public FormHTMLView()
        {
            InitializeComponent();
            // TODO:: Get this when Any CPU is supported

            if (Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("SMap.Messages", Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }
            DBLangEngine.InitalizeLanguage("SMap.Messages");
        }

        private string originalUrl = string.Empty;

        public static void Execute(string fileName, string originalUrl)
        {
            FormHTMLView frm = new FormHTMLView();

            frm.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            frm.originalUrl = originalUrl;

            frm.webBrowser.Url = new Uri(fileName);
            frm.Text = frm.webBrowser.DocumentTitle + (originalUrl == string.Empty ? string.Empty : " [" + originalUrl + "]");
            frm.Show();
        }

        private void tsbBrowserBack_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
            UpdateButtons();
        }

        private void tsbBrowserForward_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
            UpdateButtons();
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            tbWebAddress.Text = e.Url.AbsoluteUri;
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            tsbBrowserForward.Enabled = webBrowser.CanGoForward;
            tsbBrowserBack.Enabled = webBrowser.CanGoBack;
            Text = webBrowser.DocumentTitle + (originalUrl == string.Empty ? string.Empty : " [" + originalUrl + "]");
        }

        private void FormHTMLView_Shown(object sender, EventArgs e)
        {
            UpdateButtons();
        }
    }
}
