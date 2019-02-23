namespace SecKill.Infrastructure
{
    /**
    * 登录相关 2000
    * 订单相关 4000
    * 系统相关 5000
    * 其他    1000  
    */
    public class CodeMessage
    {


        /// <summary>
        /// 不能重复秒杀商品
        /// </summary>
        public static CodeMessage CONNNOT_REPEAT_SECKILL_GOODS { get; } = new CodeMessage(4000, "不能重复秒杀商品");

        /// <summary>
        /// 商品已售完
        /// </summary>
        public static CodeMessage GOODS_SOLD_OUT { get; } = new CodeMessage(4001, "商品已售完");

        public int Code { get; set; }

        public string Message { get; set; }

        public CodeMessage(int code, string message)
        {
            Code = code;
            Message = message;
        }

    }
}
