﻿using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Tracing;
using API.Diagnostics;

namespace API.Controllers.API
{
    public class TracesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            StringBuilder content = new StringBuilder();
            var entries = RingBufferLog.Instance.PeekAll();

            if (entries != null && entries.Count > 0)
            {
                int indent = 0;
                foreach (var entry in entries)
                {
                    if (Cond(entry))
                    {
                        if (entry.Kind == TraceKind.Begin)
                        {
                            var end = entries.FirstOrDefault(Condition(entry));

                            string millis = string.Empty;

                            if (end != null) millis = (end.Timestamp - entry.Timestamp).TotalMilliseconds.ToString();

                            content.Append('\t', indent);
                            content.AppendFormat("BGN {0} {1} {2} {3}\n",
                            entry.RequestId, entry.Operator,
                            entry.Operation, millis);
                            indent++;
                        }
                        else
                        {
                            indent--;
                            content.Append('\t', indent);
                            content.AppendFormat("END {0} {1} {2}\n",
                            entry.RequestId, entry.Operator, entry.Operation);
                        }
                    }
                }
            }

            return new HttpResponseMessage
            {
                Content = new StringContent(content.ToString())
            };
        }

        static bool Cond(TraceRecord entry)
        {
            return !string.IsNullOrEmpty(entry.Operation) &&
                                !string.IsNullOrEmpty(entry.Operator) &&
                                !string.IsNullOrEmpty(entry.Category);
        }

        static Func<TraceRecord, bool> Condition(TraceRecord entry)
        {
            return e =>
                entry.RequestId.Equals(e.RequestId)
                    && entry.Operator.Equals(e.Operator)
                    && entry.Operation.Equals(e.Operation)
                    && entry.Category.Equals(e.Category)
                    && e.Kind == TraceKind.End;
        }
    }
}
