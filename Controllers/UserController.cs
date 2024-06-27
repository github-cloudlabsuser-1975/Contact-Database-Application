using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here
            // Assuming 'userlist' contains a list of users you want to display
            if (!userlist.Any())
            {
                // In MVC, typically you would still return the view, possibly with an empty list
                // You can handle the "no users found" message in the view itself
                return View(new System.Collections.Generic.List<User>()); // Returns an empty list to the view
            }

            return View(userlist); // Passes the list of users to the view

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Find the user in the userlist by their ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user object to the Details view to display their information
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            // Simply return the Create view. This view should contain the form for creating a new user.
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // Add the new user to the userlist
                userlist.Add(user);

                // After adding the user to the list, redirect to the Index action to display the list of users
                return RedirectToAction("Index");
            }
            catch
            {
                // If an error occurs, return the Create view again to allow the user to correct the input
                return View();
            }
        }
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.

            // Find the user in the userlist by their ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user object to the Edit view to display the form with the user's current information
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            try
            {
                // Find the existing user in the userlist
                var existingUser = userlist.FirstOrDefault(u => u.Id == id);

                // If no user is found with the provided ID, return a HttpNotFound result
                if (existingUser == null)
                {
                    return HttpNotFound();
                }

                // Update the existing user's properties with the values from the form
                // Assuming User model has properties like Name, Email, etc.
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                // Add other properties here

                // After updating the user, redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }
            catch
            {
                // If an error occurs, return the Edit view again to allow the user to correct the input
                return View(user);
            }
        }


        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user object to the Delete view to ask for confirmation
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // Find the user in the userlist by their ID
                var user = userlist.FirstOrDefault(u => u.Id == id);

                // If the user is found, remove the user from the list
                if (user != null)
                {
                    userlist.Remove(user);
                }

                // After deleting the user, redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }
            catch
            {
                // If an error occurs, return to the Delete view for the user to try again
                return View();
            }
        }
    }
}