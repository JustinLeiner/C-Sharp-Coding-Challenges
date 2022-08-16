# [Mostly Complete]

Created a Movie Management API where customers could perform CRUD operations associated with a movie object, compare movie objects, rate movies, and make subscription payments for a movie found within the collection. 
- Incorporated Input Validation
- Checked for duplicate movies when adding a new movie to the collection


Created a Customer Management Controller endpoint where customer details could be collected, CRUD operations could be performed, included additional attributes such as customer payment methods
- Incorporated Input Validation
- Detects duplicate payment methods
- Assigns a default payment method based on credit card expiration date

Refactored movie collection to Implement an InMemoryMovieRepository and used dependency injection 
