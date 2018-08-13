namespace PGDemo.ApiCore.Model
{
    public class ApiResponse
    {
        public ApiResponse(int code, object data, string message = null)
        {
            Status = GetStatus(code);
            Code = code;
            Data = data;
            Message = message;
        }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { set; get; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { set; get; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 获取状态描述
        /// </summary>
        /// <returns></returns>
        private string GetStatus(int code)
        {
            if (code < 400)
            {
                //1XX、2XX、3XX
                return "success";
            }

            if (code >= 400 && code < 500)
            {
                return "error";
            }
                
            return "fail";
        }
    }
}
