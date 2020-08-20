using ExcelDna.Integration;

namespace KabuSuteAddin.Utils
{
    public abstract class Validate
    {

        /// <summary>
        /// トークンチェック
        /// </summary>
        [ExcelFunction(IsHidden = true)]
        public static string ValidateToken(string password)
        {
            if (string.IsNullOrEmpty(password))
                return ResultMessage.NoPasswordEntered;

            if (password.ToString().Length > 15)
                return ResultMessage.OutofRangeLength;

            // ポートチェック
            if (string.IsNullOrEmpty(CustomRibbon._port))
                return ResultMessage.NoPortEntered;

            if (!int.TryParse(CustomRibbon._port, out _))
                return ResultMessage.PortIsNotNumeric;

            if (CustomRibbon._port.Length > 5)
                return ResultMessage.OutofRangeLength;

            return null;
        }

        /// <summary>
        /// 文字列長チェック
        /// </summary>
        [ExcelFunction(IsHidden = true)]
        public int ValidateString(string value, int Length)
        {


            if (string.IsNullOrEmpty(value.ToString()))
                return ResultCode.EmptyData;

            if (Length > 0 && value.ToString().Length != Length)
                return ResultCode.OutofRangeLength;

            return ResultCode.OK;
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        [ExcelFunction(IsHidden = true)]
        public static string ValidateOrderCancel(string value1, string value2)
        {

            // 発注制御チェック
            if (!(CustomRibbon._orderPressed))
                return ResultMessage.OrderIsNotValid;

            string result = ValidateCommon();
            if (string.IsNullOrEmpty(result))
            { 

                if (string.IsNullOrEmpty(value1.ToString()))
                return ResultMessage.NotEntered;

                if (string.IsNullOrEmpty(value2.ToString()))
                    return ResultMessage.OutofRangeLength;
            }

            return result;
        }

        /// <summary>
        /// 両方入力されている場合のみOK
        /// </summary>
        [ExcelFunction(IsHidden = true)]
        public static string ValidateRequired(string value1, string value2)    
        {

            string result = ValidateCommon();

            if (string.IsNullOrEmpty(result))
                if (string.IsNullOrEmpty(value1.ToString()) || string.IsNullOrEmpty(value2.ToString()))
                    return ResultMessage.BadRequest;

            return result;
        }

        /// <summary>
        /// 両方Nullまたは両方入力されている場合のみOK
        /// </summary>
        [ExcelFunction(IsHidden = true)]
        public static string ValidateRequired2(string value1, string value2)
        {

            string result = ValidateCommon();

            if (string.IsNullOrEmpty(result))
                if (string.IsNullOrEmpty(value1.ToString()) ^ string.IsNullOrEmpty(value2.ToString()))
                    return ResultMessage.BadRequest;


            return result;
        }

        /// <summary>
        /// 入力チェック（単項目）
        /// </summary>
        [ExcelFunction(IsHidden = true)]
        public static string ValidateSingle(string value)
        {
            string result = ValidateCommon();

            if (string.IsNullOrEmpty(result))
            { 

                if (string.IsNullOrEmpty(value.ToString()))
                return ResultMessage.BadRequest;

                else if (value.ToString() == "ExcelDna.Integration.ExcelMissing")
                    return ResultMessage.BadRequest;

                else if (value.ToString() == "ExcelDna.Integration.ExcelEmpty")
                    return ResultMessage.BadRequest;
            }

            return result;
        }

        /// <summary>
        /// 入力チェック（範囲選択）
        /// </summary>
        [ExcelFunction(IsHidden = true)]
        public static string ValidateRegister(object[,] array)
        {

            string result = ValidateCommon();

            if (string.IsNullOrEmpty(result))
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if(array.GetLength(1) != 2)
                            return ResultMessage.BadRequest;

                        else if (string.IsNullOrEmpty(array[i, j].ToString()))
                            return ResultMessage.BadRequest;

                        else if (array[i, j].ToString() == "ExcelDna.Integration.ExcelMissing")
                            return ResultMessage.BadRequest;

                        else if (array[i, j].ToString() == "ExcelDna.Integration.ExcelEmpty")
                            return ResultMessage.BadRequest;

                        else if (!int.TryParse(array[i, j].ToString(), out _))
                            return ResultMessage.BadRequest;
                    }
                }

            return result;
        }

        /// <summary>
        /// 入力チェック（PUSH配信）
        /// </summary>
        [ExcelFunction(IsHidden = true)]
        public static string ValidateRtdBoard(bool WebsocketStart, string symbol, string exchange, string itemName)
        {

            string result = null;
            if (!WebsocketStart)
                result = ValidateCommon();

            if (string.IsNullOrEmpty(symbol))
                return ResultMessage.BadRequest;

            if (string.IsNullOrEmpty(exchange))
                return ResultMessage.BadRequest;

            if (!int.TryParse(exchange, out _))
                return ResultMessage.BadRequest;

            if (string.IsNullOrEmpty(itemName))
                return ResultMessage.BadRequest;

            return result;
        }

        /// <summary>
        /// 共通チェック
        /// </summary>
        [ExcelFunction(IsHidden = true)]
        public static string ValidateCommon()
        {

            // トークン取得チェック
            if (string.IsNullOrEmpty(CustomRibbon._token))
                return ResultMessage.TokenNotIssued;

            // ポートチェック
            if (string.IsNullOrEmpty(CustomRibbon._port))
                return ResultMessage.NoPortEntered;

            if (!int.TryParse(CustomRibbon._port, out _))
                return ResultMessage.PortIsNotNumeric;

            if (CustomRibbon._port.Length > 5)
                return ResultMessage.OutofRangeLength;

            return null;
        }
    }


}
