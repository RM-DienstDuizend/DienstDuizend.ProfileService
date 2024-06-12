CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Profiles" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Email" text NOT NULL,
    "FirstName" text NOT NULL,
    "LastName" text NOT NULL,
    CONSTRAINT "PK_Profiles" PRIMARY KEY ("Id")
);

CREATE TABLE "PostalAddress" (
    "Id" uuid NOT NULL,
    "StreetAddress" text NOT NULL,
    "StreetAddress2" text,
    "City" text NOT NULL,
    "Region" text NOT NULL,
    "PostalCode" text NOT NULL,
    "Country" text NOT NULL,
    "ProfileId" uuid,
    CONSTRAINT "PK_PostalAddress" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PostalAddress_Profiles_ProfileId" FOREIGN KEY ("ProfileId") REFERENCES "Profiles" ("Id")
);

CREATE INDEX "IX_PostalAddress_ProfileId" ON "PostalAddress" ("ProfileId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240524130824_Initial', '8.0.5');

COMMIT;

