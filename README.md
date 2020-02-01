# MedicalApp

Get all patients (GET):
https://localhost:44319/api/Patient/GetPatients

Get one patient (GET):
https://localhost:44319/api/Patient/GetOnePatient/{id}

Create patient (POST):
https://localhost:44319/api/Patient/CreatePatient
With body row json like :
{
    "FirstName": "Thomas",
    "LastName": "Dalphinet",
    "PhoneNumber": "0123456789",
    "Email": "thomas@thomas.fr",
    "DateOfBirth": "1999-07-27",
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

Get one physician (GET):
https://localhost:44319/api/Physician/GetOnePhysician/{id}

Create physician (POST):
https://localhost:44319/api/Physician/CreatePhysician
With body row json like :
{
    "FirstName": "Théo",
    "LastName": "Pal",
    "PhoneNumber": "0123456789",
    "Email": "theo@theo.fr"
}

Delete physician (DELETE):
https://localhost:44319/api/Physician/DeletePhysician/{id}


Get all examinations (GET):
https://localhost:44319/api/Examination/GetExamination

Get one examination (GET):
https://localhost:44319/api/Examination/GetOneExamination/{id}

Create examination (POST):
https://localhost:44319/api/Examination/CreateExamination
With body row json like :
{
    "PatientId": 3,
    "PhysicianId": 1,
    "DateAndTime": "2019-07-27",
    "Observations": "Naime pas non plus les patates douces"
}

Delete examination (DELETE):
https://localhost:44319/api/Examination/DeleteExamination/{id}
