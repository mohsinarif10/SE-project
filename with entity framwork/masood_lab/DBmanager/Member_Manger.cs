using masood_lab.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace masood_lab.DBmanager
{
    public class Member_Manger : General
    {

        public bool AddMember(MemberModel member)
        {

            tblNewMembers_registration data = new tblNewMembers_registration()
            {
                FullName = member.Fullname,
                member_username = member.member_username,
                Phonenumber = member.Phonenumber,
                Address = member.Address,
                Gender = member.Gender,
                member_Password = member.Password,
                RepeatPassword = member.RepeatPassword,
                Email = member.Email,
                NIC = member.NIC,
                Date_of_birth = member.Date_of_birth,
                ImagePath = member.ImagePath,
            };


            var dt = lib.tblNewMembers_registration.Where(x => x.member_username == member.member_username).FirstOrDefault();
            if (dt != null)
            {
                return false;
            }
            else
            {
                lib.tblNewMembers_registration.Add(data);
                lib.SaveChanges();
                data.memberID = lib.tblNewMembers_registration.Max(x => x.memberID);
                tblLogin login = new tblLogin()
                {
                    memberID = data.memberID,
                    log_pasword = data.member_Password
                };
                lib.tblLogins.Add(login);
                lib.SaveChanges();
                return true;
            }

        }

        public MemberModel getnextid()
        {
            MemberModel member = new MemberModel();
            member.memberID = lib.tblNewMembers_registration.Max(x => x.memberID) + 1;
            member.loginid_test = lib.tblLogins.Max(x => x.Loginid) + 1;
            return member;
        }

        public IList<MemberModel> Viewmember()
        {
            try
            {
                Library_systemEntities1 lib = new Library_systemEntities1();
                IList<MemberModel> members = (from q in lib.tblNewMembers_registration
                                              select new MemberModel
                                              {
                                                  memberID = q.memberID,
                                                  member_username = q.member_username,
                                                  Fullname = q.FullName,
                                                  Phonenumber = q.Phonenumber,  
                                                  NIC = q.NIC,
                                                  Password = q.member_Password,
                                                  RepeatPassword = q.RepeatPassword,
                                                  Email = q.Email,
                                                  Date_of_birth = q.Date_of_birth,
                                                  Gender = q.Gender,
                                                  Address = q.Address
                                              }).ToList();
                return members;
            }
            catch (Exception e)
            {

                throw;
            }


        }

        public MemberModel GetOneMember(int Fid)
        {
            var logindata = (from q in lib.tblLogins
                             where q.memberID == Fid
                             select new MemberModel
                             {
                                 logininfo = new LoginModel()
                                 {
                                     Loginid = q.Loginid
                                 }
                             }).FirstOrDefault();

            var member_data = (from q in lib.tblNewMembers_registration
                               where q.memberID == Fid
                               select new MemberModel
                                   {
                                       memberID = q.memberID,
                                       member_username = q.member_username,
                                       Fullname = q.FullName,
                                       Phonenumber = q.Phonenumber,
                                       NIC = q.NIC,
                                       Email = q.Email,
                                       Address = q.Address,
                                       Password = q.member_Password,
                                       RepeatPassword = q.RepeatPassword,
                                       Date_of_birth = q.Date_of_birth,
                                       Gender = q.Gender,
                                       ImagePath = q.ImagePath,
                                       logininfo = new LoginModel() { Loginid = logindata.logininfo.Loginid }

                                   }).FirstOrDefault();


            //MemberModel[] memberarray=new MemberModel[]{member_data,login_data};
            return member_data;

        }
        public bool UpdateMember(MemberModel member)
        {
            bool chk = false;
            var data = lib.tblNewMembers_registration.Where(m => m.memberID == member.memberID).FirstOrDefault();
            data.FullName = member.Fullname;
            data.Phonenumber = member.Phonenumber;  
            data.NIC = member.NIC;
            data.Address = member.Address;
            data.Email = member.Email;
            data.Date_of_birth = member.Date_of_birth;
            data.member_Password = member.Password;
            data.RepeatPassword = member.RepeatPassword;
            data.Gender = member.Gender;
            data.ImagePath = member.ImagePath;
            try
            {
                lib.SaveChanges();
                var login = lib.tblLogins.Where(x => x.Loginid == member.logininfo.Loginid).FirstOrDefault();
                login.log_pasword = member.Password;
                lib.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool DeleteMember(int Fid)
        {
            var data = lib.tblNewMembers_registration.Where(x => x.memberID == Fid).FirstOrDefault();
            bool chk = false;

            lib.tblNewMembers_registration.Remove(data);
            try
            {
                lib.SaveChanges();
                return chk = true;
            }
            catch (Exception)
            {

                return chk = false;
            }


        }



    }
}