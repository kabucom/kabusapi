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


}
