using System;
namespace CalServices.Dynamics.Messages
{
    public class SelectFieldsList
    {
        private string[] _fields;

        public SelectFieldsList(string[] Fields)
        {
            _fields = Fields;
        }

        #region Properties
        public string SelectString
        {
            get
            {
                string fields = string.Empty;
                if (_fields != null)
                {
                    fields = @"$select=";
                    for (int i = 0; i < _fields.Length; i++)
                    {
                        if (i == 0)
                        {
                            fields += _fields[i];
                        }
                        else
                        {
                            fields += $",{_fields[i]}";
                        }
                    }
                }
                return fields;
            }
        }
        #endregion
    }
}
