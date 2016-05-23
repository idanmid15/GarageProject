using System;

namespace Ex03.GarageLogic
{
    public class memberTranslator
    {
        public string m_MemberName;
        public string m_MemberTranslation;
        public Type m_MemberType;

        public memberTranslator(string i_MemberName, string i_MemberTranslation, Type i_MemberType)
        {
            this.m_MemberName = i_MemberName;
            this.m_MemberTranslation = i_MemberTranslation;
            this.m_MemberType = i_MemberType;
        }
    }
}
