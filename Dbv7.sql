
Table "tbTasks" {
  "id" int [pk, increment]
  "idPC" int [not null]
  "idConfig" int [not null]
  "Status" BINARY [default: 1]
}

Table "tbPC" {
  "id" int [pk, increment]
  "Name" varchar(20)
  "MACAddress" varchar(15) [not null]
  "IPAddress" varchar(15) [not null]
  "Status" BINARY [not null]
}

Table "tbGroups" {
  "id" int [pk, increment]
  "Name" varchar(50) [not null]
}

Table "tbPCGroups" {
  "id" int [pk, increment]
  "idPC" int [not null]
  "idGroup" int [not null]
}

Table "tbAdmins" {
  "id" int [pk, increment]
  "Username" varchar(20) [not null]
  "Password" varchar(50) [not null]
  "Email" varchar(60) [not null]
  "ProfilePicture" blob
  "RepeatPeriod" text
}

Table "tbReports" {
  "id" int [pk, increment]
  "idPC" int [not null]
  "Status" BINARY [not null]
  "ReportTime" datetime
  "Description" text
}

Table "tbConfigs" {
  "id" int [pk, increment]
  "Type" char(4) [not null]
  "RepeatPeriod" text
  "ExpirationDate" datetime
  "Compress" BINARY [default: 0]
  "Retention" int [default: 0]
  "PackageSize" int [default: 0]
  "CreatedBy" int
}

Table "tbSources" {
  "id" int [pk, increment]
  "idConfig" int
  "path" text
}

Table "tbDestinations" {
  "id" int [pk, increment]
  "idConfig" int
  "Type" BINARY [not null]
  "Config" text [not null]
}

Ref:"tbPC"."id" < "tbTasks"."idPC"

Ref:"tbPC"."id" < "tbPCGroups"."idPC"

Ref:"tbGroups"."id" < "tbPCGroups"."idGroup"

Ref:"tbConfigs"."id" < "tbTasks"."idConfig"

Ref:"tbPC"."id" < "tbReports"."idPC"

Ref:"tbConfigs"."id" < "tbSources"."idConfig"

Ref:"tbConfigs"."id" < "tbDestinations"."idConfig"


Ref: "tbAdmins"."id" < "tbConfigs"."CreatedBy"