using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Codeplex.Data;
using ExcelDna.Integration;
using ExcelDna.Integration.CustomUI;

namespace KabuSuteAddin
{
    [ComVisible(true)]
    public class CustomRibbon : ExcelRibbon
    {

        private string xmlPath = Path.GetDirectoryName(ExcelDnaUtil.XllPath) + @"\KabuSuteAddinSetting.xml";
        private IRibbonUI _thisRibbon;
        public static bool _orderPressed;
        public static bool _updatePressed;
        private int _rbSelectedItemIndex = 1;
        // トークンボタン
        private string _environment;

        // ドロップダウン
        public static bool _env = false;

        // ポート番号
        public static string _port;

        // API Password
        public static string _prodApiPassword;
        public static string _devApiPassword;

        // token系
        private bool _tokenProd;
        private bool _tokenDev;
        private string _prodToken;
        private string _devToken;
        public static string _token;

        public override string GetCustomUI(string RibbonID)
        {
            string ribbonXml = GetCustomRibbonXML();
            return ribbonXml;
        }

        private string GetCustomRibbonXML()
        {

            return @"
            <customUI xmlns='http://schemas.microsoft.com/office/2006/01/customui' onLoad='OnLoad'>
                <ribbon>
                  <tabs>
                    <tab id='KabusAddinTab' label='kabuSTATION アドイン'>
                    <group id='KabusAddinGroup' label='制御ボタン'>
                      <toggleButton id='OrderButton' label='発注制御' screentip='発注制御' supertip='注文可能、不可能の切り替えを行います。' getImage='GetImage' size='large' getPressed='TogglePressed' onAction='TogglePressAction'/>
                      <separator id='separator1'/>
                      <toggleButton id='UpdateButton' label='更新制御' screentip='更新制御' supertip='PUSH配信する関数の自動更新のON・OFFを切り替えます。' getImage='GetImage' size='large' getPressed='TogglePressed' onAction='TogglePressAction'/>
                    </group >
                    <group id='KabusAddinEnvGroup' label='使用環境'>
                      <labelControl id='labelControl1'/>
                      <dropDown id='dropDownUseToken' screentip='使用環境' supertip='選択した環境のトークンを使用してAPIに接続します。' showItemLabel='true' getSelectedItemIndex='getSelectedItemIndex' onAction='dropDown_onAction'>
                      <item id='dropDownUseToken_Prod' label='本番用' screentip='本番用' supertip='本番用ログインで取得したトークンを使用します。' />
                      <item id='dropDownUseToken_Dev' label='検証用' screentip='検証用' supertip='検証用ログインで取得したトークンを使用します。' />
                      </dropDown>
                    </group >
                    <group id='KabusAddinPortGroup' label='ポート'>
                      <labelControl id='labelControl2'/>
                      <editBox id='PortBox' screentip='ポート' supertip='APIを使用するポートを指定してください。' maxLength='5' sizeString='WWWW' getText='GetText' onChange='OnChangeEditBox' />
                    </group >
                    <group id='KabusAddinPasswordGroup' label='APIパスワード'>
                      <box id='box1' >
                        <editBox id='ProdApiPassword' label='本番用:' screentip='APIパスワード(本番用)' supertip='本番用APIにログインするパスワードを指定してください。' maxLength='16' sizeString='WWWWWMMMMMWWWWWM' getText='GetText' onChange='OnChangeEditBox' />
                        <button id='ProdTokenButton' label='本番用ログイン' screentip='本番用トークン取得' supertip='本番用のトークンを取得します。' getImage='GetImage' size='normal' onAction='ButtonPressAction'/>
                      </box>
                      <box id='box2' >
                        <editBox id='DevApiPassword' label='検証用:' screentip='APIパスワード(検証用)' supertip='検証用APIにログインするパスワードを指定してください。' maxLength='16' sizeString='WWWWWMMMMMWWWWWM' getText='GetText' onChange='OnChangeEditBox' />
                        <button id='DevTokenButton' label='検証用ログイン' screentip='APIパスワード(検証用)' supertip='検証用のトークンを取得します。' getImage='GetImage' size='normal' onAction='ButtonPressAction'/>
                      </box>
                    </group >
                    </tab>
                  </tabs>
                </ribbon>
            </customUI>";
        }

        /// <summary>
        /// リボンのロード処理
        /// </summary>
        public void OnLoad(IRibbonUI ribbon)
        {

            XElement xml = XElement.Load(xmlPath);
            IEnumerable<XElement> infos = from item in xml.Elements("setting1")
                                          select item;

            foreach (XElement info in infos)
            {
                _orderPressed = info.Element(RibbonItem.発注制御ボタン).Value == "1" ? true : false;
                _updatePressed = info.Element(RibbonItem.更新制御ボタン).Value == "1" ? true : false;
                _port = info.Element(RibbonItem.ポート入力ボックス).Value;
            }

            _thisRibbon = ribbon ?? throw new ArgumentNullException(nameof(ribbon));

            settingUpdate("ApiToken", "");
        }

        private void OnInvalidateRibbon(object obj)
        {
            _thisRibbon.Invalidate();
        }

        /// <summary>
        /// アイコン設定
        /// </summary>
        public Bitmap GetImage(IRibbonControl control)
        {
            switch (control.Id)
            {
                case RibbonItem.発注制御ボタン:
                    return _orderPressed ? new Bitmap(Properties.Resources.注文OK_32x32_透過): new Bitmap(Properties.Resources.注文NG_32x32_透過);

                case RibbonItem.更新制御ボタン:
                    return _updatePressed ? new Bitmap(Properties.Resources.更新OK_32x32_透過) : new Bitmap(Properties.Resources.更新NG_32x32_透過);

                case RibbonItem.本番用トークン取得ボタン:
                    return _tokenProd ? new Bitmap(Properties.Resources.kabuSTATIONAPI_ExcelToken_本番_LOGIN状態_32x32_透過) : new Bitmap(Properties.Resources.kabuSTATIONAPI_ExcelToken_本番_通常状態_32x32_透過);

                case RibbonItem.検証用トークン取得ボタン:
                    return _tokenDev ? new Bitmap(Properties.Resources.kabuSTATIONAPI_ExcelToken_検証_LOGIN状態_32x32_透過) : new Bitmap(Properties.Resources.kabuSTATIONAPI_ExcelToken_検証_通常状態_32x32_透過);

                default: return null;
            }
        }


        /// <summary>
        /// togguleButton押下
        /// </summary>
        public void TogglePressAction(IRibbonControl control, bool pressed)
        {
            switch (control.Id)
            {
                case RibbonItem.発注制御ボタン:
                    _orderPressed = pressed;
                    _thisRibbon.InvalidateControl(RibbonItem.発注制御ボタン);
                    break;

                case RibbonItem.更新制御ボタン:
                    _updatePressed = pressed;
                    _thisRibbon.InvalidateControl(RibbonItem.更新制御ボタン);
                    break;

                default: break;
            }

            string val = pressed ? "1" : "0";
            settingUpdate(control.Id, val);
        }

        /// <summary>
        /// toggleButtonのチェック状態
        /// </summary>
        public bool TogglePressed(IRibbonControl control)
        {
            switch (control.Id)
            {
                case RibbonItem.発注制御ボタン: 
                    return _orderPressed;

                case RibbonItem.更新制御ボタン: 
                    return _updatePressed;

                default:
                    return false;
            }
        }


        /// <summary>
        /// buttonコントロール押下時
        /// </summary>
        public void ButtonPressAction(IRibbonControl control)
        {

            bool token = false;

            switch (control.Id)
            {
                case RibbonItem.本番用トークン取得ボタン:
                    _prodToken = getToken(_prodApiPassword, ref token);
                    _tokenProd = token;
                    _thisRibbon.InvalidateControl(RibbonItem.本番用トークン取得ボタン);

                    if (_environment == RibbonItem.本番用トークン)
                    {
                        _token = _prodToken;
                    }
                    break;

                case RibbonItem.検証用トークン取得ボタン:
                    _devToken = getToken(_devApiPassword, ref token);
                    _tokenDev = token;
                    _thisRibbon.InvalidateControl(RibbonItem.検証用トークン取得ボタン);

                    if (_environment == RibbonItem.検証用トークン)
                    {
                        _token = _devToken;
                    }
                    break;

                default: break;
            }

            settingUpdate("ApiToken", _token); 
        }

        /// <summary>
        /// editBoxにテキストを設定する
        /// </summary>
        public string GetText(IRibbonControl control)
        {

            switch (control.Id)
            {
                case "PortBox":
                    return _port;

                case "ProdApiPassword":
                    return _prodApiPassword;

                case "DevApiPassword":
                    return _devApiPassword;

                default:
                    return "0";
            }
        }

        /// <summary>
        /// editBoxの変更(onChange)。onChangeはフォーカスアウト、または[enter]キー押下時に発生
        /// </summary>
        public void OnChangeEditBox(IRibbonControl control, string val)
        {

            switch (control.Id)
            {
                case "PortBox":
                    _port = val;
                    settingUpdate(control.Id, val);
                    break;

                case "ProdApiPassword":
                    _prodApiPassword = val;
                    break;

                case "DevApiPassword":
                    _devApiPassword = val;
                    break;

                default:
                    break;
            }

        }

        /// <summary>
        /// DropDownのクリック処理
        /// </summary>
        public void dropDown_onAction(IRibbonControl control, String item_ID, int index)
        {
            _environment = item_ID;

            switch (item_ID)
            {
                case RibbonItem.本番用トークン:
                    _token = _prodToken;
                    _env = true;
                    break;

                case RibbonItem.検証用トークン:
                    _token = _devToken;
                    _env = false;
                    break;

                default:
                    break;
            }

            settingUpdate("ApiToken", _token);

        }


        private string getToken (string apiPassword, ref bool token)
        {
            var strJson = ExcelFunctionController.KABUSUTE_API_TOKEN(apiPassword);
            string response = "";

            try
            { 
                var objectJson = DynamicJson.Parse(strJson);

                if (objectJson.IsDefined("ResultCode"))
                {
                    if (objectJson.ResultCode == 0)
                    {
                        token = true;
                        return objectJson.Token;
                    }
                    else
                    {
                        token = false;
                        MessageBox.Show("不明なエラーです");
                    }
                }
                else if(objectJson.IsDefined("Code"))
                {
                    token = false;
                    MessageBox.Show("Code " + objectJson.Code +":" +  objectJson.Message);
                }
            }
            catch (Exception exception)
            {
                if(exception.InnerException == null)
                    MessageBox.Show(strJson);
                else
                    MessageBox.Show(exception.InnerException.ToString());

            }

            return response;

        }


        public void getSelectedItemIndex(IRibbonControl control, ref int index)
        {
            index = _rbSelectedItemIndex;
        }

        private void settingUpdate(string control, string val)
        {
            XElement xml = XElement.Load(xmlPath);

            IEnumerable<XElement> infos = from item in xml.Elements("setting1")
                                          select item;

            //if (!string.IsNullOrEmpty(val))
            //{
            foreach (XElement info in infos)
            {
                if (!string.IsNullOrEmpty(val))
                    info.Element(control).Value = val;

                else
                    info.Element(control).Value = "";
            }
            //}
            xml.Save(xmlPath);
        }

    }
}
