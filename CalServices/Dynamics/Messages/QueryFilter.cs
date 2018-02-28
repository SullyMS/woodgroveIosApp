using System;
using System.Collections.Generic;

namespace CalServices.Dynamics.Messages
{
    public class QueryFilter
    {
        #region Members
        private List<FilterCriteria> _criteria = null;
        #endregion

        public QueryFilter()
        {
            _criteria = new List<FilterCriteria>();
        }

        public string QueryString
        {
            get
            {
                string query = "&$filter=";
                bool isFirstCritera = true;
                foreach (FilterCriteria c in _criteria)
                {
                    if (isFirstCritera)
                    {
                        query += c.GetCriteriaString(false);
                        isFirstCritera = false;
                    }
                    else
                    {
                        query += c.GetCriteriaString();
                    }
                }

                return Uri.EscapeUriString(query);
            }
        }


        public void AddCriteria(string Field, ComparisonOperators ComparisonOperator, object Value, LogicalOperators LogicalOperator = LogicalOperators.And)
        {
            FilterCriteria filter = new FilterCriteria(Field, ComparisonOperator, LogicalOperator, Value);
            _criteria.Add(filter);
        }

        sealed class FilterCriteria
        {
            public FilterCriteria(string Field, ComparisonOperators ComparisonOperator, LogicalOperators LogicalOperator, object Value)
            {
                this.Field = Field;
                this.ComparisonOperator = ComparisonOperator;
                this.LogicalOperator = LogicalOperator;
                this.Value = Value;
            }
            public string Field { get; private set; }
            public ComparisonOperators ComparisonOperator { get; private set; }
            public LogicalOperators LogicalOperator { get; set; }
            public object Value { get; set; }

            public string GetCriteriaString(bool IncludeLogicalOperator = true)
            {
                string criteria = string.Empty;
                if (IncludeLogicalOperator)
                {
                    criteria = $" {GetLogicalOperator(LogicalOperator)} {Field} {GetComparisonOperator(ComparisonOperator)} {FormatValue(Value)}";
                }
                else
                {
                    criteria = $"{Field} {GetComparisonOperator(ComparisonOperator)} {FormatValue(Value)}";
                }
                return criteria;
            }

            private string FormatValue(object MatchValue)
            {
                string value = string.Empty;
                if (MatchValue.GetType().Equals(typeof(string)))
                {
                    Guid id = Guid.Empty;
                    //test for guid
                    if (Guid.TryParse(MatchValue.ToString(), out id))
                    {
                        value = MatchValue.ToString();
                    }
                    else
                    {
                        value = $"'{MatchValue}'";
                    }
                }
                else if (MatchValue.GetType().Equals(typeof(DateTime)))
                {
                    value = $"{((DateTime)MatchValue).ToString("O")}";
                }
                else
                {
                    value = $"{MatchValue}";
                }

                return value;
            }

            private string GetLogicalOperator(LogicalOperators Operator)
            {
                switch (Operator)
                {
                    case LogicalOperators.And:
                        return "and";
                    case LogicalOperators.Or:
                        return "or";
                    case LogicalOperators.Not:
                        return "not";
                    default:
                        return string.Empty;
                }
            }

            private string GetComparisonOperator(ComparisonOperators Operator)
            {
                switch (Operator)
                {
                    case ComparisonOperators.Equal:
                        return "eq";
                    case ComparisonOperators.NotEqual:
                        return "ne";
                    case ComparisonOperators.GreaterThan:
                        return "gt";
                    case ComparisonOperators.GreatThanOrEqual:
                        return "ge";
                    case ComparisonOperators.LessThan:
                        return "lt";
                    case ComparisonOperators.LessThanOrEqual:
                        return "le";
                    default:
                        return string.Empty;
                }
            }
        }
    }



    public enum ComparisonOperators
    {
        Equal,
        NotEqual,
        GreaterThan,
        GreatThanOrEqual,
        LessThan,
        LessThanOrEqual
    }

    public enum LogicalOperators
    {
        And,
        Or,
        Not
    }
}
