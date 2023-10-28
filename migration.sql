CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231027023826_InitialMigration') THEN
    CREATE TABLE blog (
        "BlogId" serial NOT NULL,
        "Url" text NOT NULL,
        "Rating" integer NOT NULL,
        CONSTRAINT "PK_blog" PRIMARY KEY ("BlogId")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231027023826_InitialMigration') THEN
    CREATE TABLE post (
        "PostId" serial NOT NULL,
        "Title" text NOT NULL,
        "Content" text NOT NULL,
        "BlogId" integer NOT NULL,
        CONSTRAINT "PK_post" PRIMARY KEY ("PostId"),
        CONSTRAINT "FK_post_blog_BlogId" FOREIGN KEY ("BlogId") REFERENCES blog ("BlogId") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231027023826_InitialMigration') THEN
    CREATE INDEX "IX_post_BlogId" ON post ("BlogId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231027023826_InitialMigration') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20231027023826_InitialMigration', '7.0.13');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231027024911_ProofOfLifeMigration') THEN
    CREATE TABLE proof (
        "Id" uuid NOT NULL,
        CONSTRAINT "PK_proof" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231027024911_ProofOfLifeMigration') THEN
    INSERT INTO proof ("Id")
    VALUES ('e46b421d-84d1-4fbe-b098-28b1438e0892');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231027024911_ProofOfLifeMigration') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20231027024911_ProofOfLifeMigration', '7.0.13');
    END IF;
END $EF$;
COMMIT;

