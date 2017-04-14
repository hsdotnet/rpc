namespace Framework.Rpc.Core.Monitor
{
    public class StatisticsInfo
    {
        /// <summary>
        /// 成功次数
        /// </summary>
        public long Success { get; set; }

        /// <summary>
        /// 失败次数
        /// </summary>
        public long Failure { get; set; }

        /// <summary>
        /// 每秒请求次数
        /// </summary>
        public float QPS { get; set; }

        /// <summary>
        /// 最大响应时间
        /// </summary>
        public long MaxTime { get; set; }

        /// <summary>
        /// 最小响应时间
        /// </summary>
        public long MinTime { get; set; }

        /// <summary>
        /// 平均响应时间
        /// </summary>
        public float AvgTime { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Time { get; set; }
    }
}
