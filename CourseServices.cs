using System;
using System.Collections.Generic;

namespace cs330_proj1
{
    public class CourseServices
    {
        private CourseRepository repo = new CourseRepository();


         //As a student, I want to search for course offerings that meet core goals 
        // so that I can register easily for courses that meet my program requirements
         public List<CourseOffering> getOfferingsByGoalIdAndSemester(String theGoalId, String semester) {
          //finish this method during the tutorial 
          //use the repo to get the data from the database (data store)
         List<CoreGoal> theGoals = repo.Goals;
         List<CourseOffering> theOfferings = repo.Offerings;
            
//Complete any other required functionality/business logic to satisfy the requirement
         CoreGoal theGoal=null;
         foreach(CoreGoal cg in theGoals) {
         if(cg.Id.Equals(theGoalId)) {
            theGoal=cg; break;
 
            }
         }
         if(theGoal==null) throw new Exception("Didn't find the goal");
         //search list of courses, then for each course, search offerings
       List<CourseOffering> courseOfferingsThatMeetGoal = new List<CourseOffering>();
            
      foreach(CourseOffering c in theOfferings) {
      if(c.Semester.Equals(semester) 
         && theGoal.Courses.Contains(c.TheCourse) ) 
       {
            courseOfferingsThatMeetGoal.Add(c);
       }
 
      }
       return courseOfferingsThatMeetGoal;
        }
        
     }
}

