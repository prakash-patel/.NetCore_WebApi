# .Net Core Web API

Run [.Net Core][] in mac and windows box.

## Getting Started

### Dependencies

You have to install below software in order to run this code.

1. Install [.Net Core][]
1. Install [Postman][]

## version

1. .Net Core (1.0.0-preview2-1-003177)


Unless if you want to change this version please go to `global.json` file and Apply that version. I recommend to use current version.

## How to start

### See it in action

Run below command at `C:\Users\pakiyabhai\Documents\Visual Studio 2015\Projects\user_management_api\src\hackMT.UserMgmt` lavel
```
$ dotnet restore
$ dotnet build
$ dotnet run
```
If you getting any databse related issue. Pleae delete `UserMgmt.db` file and run below command.
```
$ dotnet ef database update
```

Once above command run successfully, go to postman, choose GET and write `http://localhost:5000/users/v1/status`. It should prodive you status of the API.


## API Definition

### Create a new user
#### POST /users/v1/
Request
```json
 {
  "username": "Luke",
  "email": "Luke1@ilove.gov",
  "password": "MonkeyLuvr7",
  "old_password": "",
  "new_password": "",
  "avatar_url": "http://imgur.com/w32"
}
```
Response
```json
{
  "user_id": 1,
  "username": "Luke",
  "email": "Luke1@ilove.gov",
  "password": "MonkeyLuvr7",
  "old_password": "",
  "new_password": "",
  "avatar_url": "http://imgur.com/w32",
  "api_token": "3196b76f-60f3-45b6-a568-53db426c1d34"
}
```

### Update an existing user
#### PATCH /users/v1/<user_id>

On this you must send the user_id.  All other fields are optional.  Any field sent will be updated.

Request
```json
{
   "user_id": "a87sdf87as87fd87saf6sa8",
   "username": "newuser",
   "old_password": "98dsa798fd9fdsa98kj32kj32",
   "new_password": "98dsa798fd9fdsa98kj32kj32",
}
```

Response
```json
{
   "user_id": "97ad9f7a9sd7f9",
   "status": "<success | failed>",
   "message": "<error message>"
}
```


### List all users
#### GET /users/v1

Returns a list of user objects.

Response
```json
[{
  "user_id": "98dsa7f9sd97f79a8df79s",
  "username": "foobar", 
  "email": "foo@bar.com", 
  "password": "98a7dsf98sa7fd98asd89d9a8df",
  "avatar_url": "http://imgur.com/9dsa99as9d8f"
},
{
  "user_id": "98ds3f3f43f334wqr23wer8dsadf8s",
  "username": "barfoo", 
  "email": "bar@foo.com", 
  "password": "98a7adssaddsfadsdsafsd89d9a8df",
  "avatar_url": "http://imgur.com/9dsa99as9d8f"
}]
```

### Details for a single user
#### GET /users/v1/<user_id>

Returns all the details (fields) for a single user.

Response
```json
{
  "user_id": "98dsa7f9sd97f79a8df79s",
  "username": "foobar", 
  "email": "foo@bar.com", 
  "password": "98a7dsf98sa7fd98asd89d9a8df",
  "avatar_url": "http://imgur.com/9dsa99as9d8f",
  "api_token": "b7f88e9f-28be-4f50-b4b9-442c9b12ac54"
}
```


### Delete a user
#### DELETE /users/v1/<user_id>

Deletes a user from the database (this marks a user as deleted so other tables/services keep working).

Response
```json
{
   "user_id": "97ad9f7a9sd7f9",
   "status": "<success | failed>",
   "message": "<error message>"
}
```

### Health Status
#### GET /users/v1/status

This provides a mechanism for monitoring tools to see the health of the api.

Response
```json
{
   "status": "online",
   "user_count": "73"
}
```


### Who do I talk to?

* Repo owner or admin

[.Net Core]: https://go.microsoft.com/fwlink/?LinkID=835014
[Postman]: https://chrome.google.com/webstore/detail/postman/fhbjgbiflinjbdggehcddcbncdddomop?utm_source=chrome-ntp-icon