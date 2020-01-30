# MedicalApp

Get all patients (GET):
https://localhost:44319/api/Patient/GetPatients

Get one patient (GET):
https://localhost:44319/api/Patient/GetOnePatient/{id}

Create patients (POST):
https://localhost:44319/api/Patient/CreatePatient
With body row json like :
{
    "FirstName": "Thomas",
    "LastName": "Dalphinet",
    "PhoneNumber": "0123456789",
    "Email": "thomas@thomas.fr",
    "DateOfBirth": "1999-24-07",
    "Pathologies": "Naime pas les épinards"
}

Update patient's pathologies (PUT):
https://localhost:44319/api/Patient/UpdatePatientPathologies/{id}
With body row string like :
"Naime pas les tomates"

Delete patient (DELETE):
https://localhost:44319/api/Patient/DeletePatient/{id}


Get all physicians (GET):
https://localhost:44319/api/Physician/GetPhysicians

Get one physicians (GET):
https://localhost:44319/api/Physician/GetOnePhysician/{id}

Create physicians (POST):
https://localhost:44319/api/Physician/CreatePhysician
With body row json like :
{
    "FirstName": "Théo",
    "LastName": "Pal",
    "PhoneNumber": "0123456789",
    "Email": "theo@theo.fr"
}

Delete physicians (DELETE):
https://localhost:44319/api/Physician/DeletePhysician/{id}
