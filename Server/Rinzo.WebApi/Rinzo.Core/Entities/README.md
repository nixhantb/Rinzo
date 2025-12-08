## BaseEntity
The BaseEntity class represents the fundamental structure for entities in the ```JobLeet.Core``` namespace. It includes common properties such as Id for identification, CreatedAt for creation timestamp, UpdatedAt for the last update timestamp, and DeletedAt for soft deletion timestamp.

### Properties:
- ```Id```: Unique identifier for the entity.
- ```CreatedAt```: Timestamp indicating when the entity was created.
- ```UpdatedAt```: Timestamp indicating the last update to the entity.
- ```DeletedAt```: Timestamp indicating when the entity was soft-deleted (nullable for non-deleted entities).