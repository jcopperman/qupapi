# QUp Api
Web api written in ASP.Net C# for quality assurance app - QUp

Instructions:
Build and run the solution.
Swagger is included in this project and an api UI is displayed with the api documentation by navigating to localhost/swagger while running the application.

Description:

Project: The top parent model with ProjectId, ProjectName and mapping to SprintModel

Sprint: Child of Project with SprintId, SprintName and mapping to FeaturesModel

Features: Child of Sprint with FeatureId, FeatureDescription, mappings to SprintModel, FeatureStoryModel, UserStoryModel and FileResult(for attachments)

FeatureStory: Child of Features with FeatureStoryId, FeatureStory("AS A tester I WANT to add and edit Features SO THAT I can track acceptance criteria") with mapping to UserStoryModel

UserStory: Contains UserStoryId, UserStory("GIVEN I have created a sprint WHEN I add a new feature THEN that feature is included in that sprint) with mapping to StatusModel

Status: Model for Statuses with StatusId and Status("Pass, Fail, Pending, etc)
