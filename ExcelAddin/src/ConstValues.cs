using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KabuSuteAddin
{
    public class ResultCode
    {
        /// <summary>OK</summary>
        public const int OK = 0;

        /// <summary>内部エラー</summary>
        public const int Internal = -1;

        /// <summary>ユーザー情報が見つかりませんでした。</summary>
        public const int NotFoundUserInfo = 2;

        /// <summary>ユーザー情報が不正な状態です。</summary>
        public const int InvalidUserID = 3;

        /// <summary>データが見つかりませんでした。</summary>
        public const int NotFoundData = 10;
        /// <summary>定義値が不正です。</summary>
        /// 
        public const int InvalidConstValues = 11;

        /// <summary>フォーマットが不正です。</summary>
        public const int InvalidFormat = 12;

        /// <summary>キャッシュが有効期限内です。</summary>
        public const int CacheValidityEnable = 20;

        #region 入力値バリデータ
        /// <summary>データが入力されていません。</summary>
        public const int EmptyData = 501;

        /// <summary>データの桁数が不正です。</summary>
        public const int OutofRangeLength = 502;

        #endregion

    }


    #region リボンの項目ID
    public class RibbonItem
    {
        /// <summary>リボンのタブID</summary>
        public const string tabId = "KabusAddinTab";

        /// <summary>発注制御ボタンID</summary>
        public const string 発注制御ボタン = "OrderButton";

        /// <summary>更新制御ボタンID</summary>
        public const string 更新制御ボタン = "UpdateButton";

        /// <summary>ポート番号</summary>
        public const string ポート入力ボックス = "PortBox";

        /// <summary>更新制御ボタンID</summary>
        public const string APIパスワード_本番 = "ProdApiPassword";

        /// <summary>更新制御ボタンID</summary>
        public const string APIパスワード_検証 = "DevApiPassword";

        /// <summary>トークン取得ボタン（本番用）</summary>
        public const string 本番用トークン取得ボタン = "ProdTokenButton";

        /// <summary>トークン取得ボタン（検証用）</summary>
        public const string 検証用トークン取得ボタン = "DevTokenButton";

        /// <summary>使用環境を選択するドトップダウン</summary>
        public const string 使用環境ドロップダウン = "dropDownUseToken";

        /// <summary>本番用のドロップダウンアイテム</summary>
        public const string 本番用トークン = "dropDownUseToken_Prod";

        /// <summary>検証用のドロップダウンアイテム</summary>
        public const string 検証用トークン = "dropDownUseToken_Dev";

    }
    #endregion

    #region 取引余力
    public class WALLET
    {
        /// <summary>現物</summary>
        public const string CASH = "cash";

        /// <summary>信用</summary>
        public const string MARGIN = "margin";

        /// <summary>先物</summary>
        public const string FUTURE = "future";

        /// <summary>オプション</summary>
        public const string OPTION = "option";

    }
    #endregion

    #region メッセージ
    public class ResultMessage
    {
        /// <summary>リクエストパラメータチェック</summary>
        public const string NotEntered = "データが入力されていません。";
        public const string BadRequest = "パラメータが不正です";
        public const string OutofRangeLength = "データの桁数が不正です";

        /// <summary>発注Off</summary>
        public const string OrderIsNotValid = "発注が無効になっています";

        /// <summary>更新Off</summary>
        public const string UpdateIsNotValid = "更新が無効になっています";

        /// <summary>トークン未発行</summary>
        public const string TokenNotIssued = "トークンが発行されていません";

        /// <summary>パスワードチェック</summary>
        public const string NoPasswordEntered = "パスワードが入力されていません";

        /// <summary>ポートチェック</summary>
        public const string NoPortEntered = "ポート番号が入力されていません。";
        public const string PortIsNotNumeric = "ポート番号は数値を入力してください";

    }
    #endregion

    #region 種別
    public class TYPE
    {
        /// <summary>
        /// 値上がり率（デフォルト）
        /// </summary>
        public const string PriceIncreaseRate = "1";
        /// <summary>
        /// 値下がり率
        /// </summary>
        public const string PriceDropRate = "2";
        /// <summary>
        /// 売買高上位
        /// </summary>
        public const string TopTradingVolume = "3";
        /// <summary>
        /// 売買代金
        /// /// </summary>
        public const string TradingPrice = "4";
        /// <summary>
        /// TICK回数
        /// /// </summary>
        public const string TickCount = "5";
        /// <summary>
        /// 売買高急増
        /// /// </summary>
        public const string RapidIncreaseInTradingVolume = "6";
        /// <summary>
        /// 売買代金急増
        /// /// </summary>
        public const string RapidIncreaseInTradingValue = "7";
        /// <summary>
        /// 信用売残増
        /// /// </summary>
        public const string IncreasedCreditSales = "8";
        /// <summary>
        /// 信用売残減
        /// /// </summary>
        public const string CreditSalesLoss = "9";
        /// <summary>
        /// 信用買残増
        /// /// </summary>
        public const string IncreasedCreditPurchase = "10";
        /// <summary>
        /// 信用買残減
        /// /// </summary>
        public const string CreditPurchaseBalanceReduction = "11";
        /// <summary>
        /// 信用高倍率
        /// /// </summary>
        public const string CreditHighMagnification = "12";
        /// <summary>
        /// 信用低倍率
        /// /// </summary>
        public const string CreditLowMagnification = "13";
        /// <summary>
        /// 業種別値上がり率
        /// /// </summary>
        public const string PriceIncreaseRateByCategory = "14";
        /// <summary>
        /// 業種別値下がり率
        /// /// </summary>
        public const string PriceReductionRateByCategory = "15";

    }
    #endregion

}