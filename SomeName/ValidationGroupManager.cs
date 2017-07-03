using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    public class ValidationGroupManager
    {
        static private ValidationGroupManager _instance = null;
        private List<ValidationGroup> _groupList;

        private ValidationGroupManager()
        {
            _groupList = new List<ValidationGroup>();

            ValidationGroup group = new AndValidationGroup("Default");

            _groupList.Add(group);
        }

        static public ValidationGroupManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ValidationGroupManager();
            }

            return _instance;
        }

        public bool CreateGroup(string groupName, GroupType type)
        {
            for (int i = 0; i < _groupList.Count; i++)
            {
                if (_groupList[i].Name == groupName)
                {
                    // TODO: Trả error đã tồn tại group name cho dave
                    // ErrorManager.ThrowDevError("CreateGroup", "Group name already exsist");
                    return false;
                }
            }

            switch(type)
            {
                case GroupType.And:
                    {
                        ValidationGroup group = new AndValidationGroup(groupName);
                        _groupList.Add(group);
                    }
                    break;
                case GroupType.Or:
                    {
                        ValidationGroup group = new OrValidationGroup(groupName);
                        _groupList.Add(group);
                    }
                    break;
            }

            return true;
        }

        public bool AddValidationToGroup(Validation v, string groupName)
        {
            for (int i = 0; i < _groupList.Count; i++)
            {
                if (_groupList[i].Name == groupName)
                {
                    v.attach(_groupList[i]);
                    return true;
                }
            }

            // TODO: Trả error group không tồn tại group name cho dave
            // ErrorManager.ThrowDevError("AddValidationToGroup", "Group name doesn't exsist");
            return false;
        }

        public bool RemoveValidationFromGroup(Validation v, string groupName)
        {
            for (int i = 0; i < _groupList.Count; i++)
            {
                if (_groupList[i].Name == groupName)
                {
                    v.detach(_groupList[i]);
                    return true;
                }
            }

            // TODO: Trả error group không tồn tại group name cho dave
            // ErrorManager.ThrowDevError("RemoveValidationFromGroup", "Group name doesn't exsist");
            return false;
        }

        public bool isValid()
        {
            bool Valid = true;

            for (int i = 0; i < _groupList.Count; i++)
            {
                if (!_groupList[i].isValid())
                {
                    Valid = false;
                }
            }

            return Valid;
        }
    }
}
