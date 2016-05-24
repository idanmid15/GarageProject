using System;

namespace Ex03.GarageLogic
{
    public class MemberTranslator
    {
        public string m_MemberName;
        public string m_MemberTranslation;
        public Type m_MemberType;

        public MemberTranslator(string i_MemberName, Type i_MemberType)
        {
            this.m_MemberName = i_MemberName;
            this.m_MemberType = i_MemberType;
        }
    }
}
