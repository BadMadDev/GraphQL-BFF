# GraphQL-BFF
This is a training repository to proof using GraphQL as a BFF (Backend-For-Frontend)

# Fist Usage 

### Customer Service 

- set Customer.Service as startup project 
- start Customer.Service project as self hosted 
- call http://localhost:5010/ui/altair
- use query 

```
query {
  customer(id: "44C2D406-5BEB-43EF-A16E-4469FD369036") {
    id
    firstname
    lastname
  }
}
```
Result: 
```
{
  "data": {
    "customer": {
      "id": "44c2d406-5beb-43ef-a16e-4469fd369036",
      "firstname": "Hans",
      "lastname": "Werner"
    }
  },
  "extensions": {
    "tracing": {
      "version": 1,
      "startTime": "2021-07-16T08:40:52.9996214Z",
      "endTime": "2021-07-16T08:40:53.2736214Z",
      "duration": 273794500,
      "parsing": {
        "startOffset": 74071000,
        "duration": 12486400
      },
      "validation": {
        "startOffset": 86680300,
        "duration": 19142600
      },
      "execution": {
        "resolvers": []
      }
    }
  }
}

```

### Order Service 

- set Order.Service as startup project 
- start Order.Service project as self hosted 
- call http://localhost:5020/ui/altair
- use query 

```
query {
  order(id: "72d95bfd-1dac-4bc2-adc1-f28fd43777fd") {
    id
    orderEntries {
     description 
    }
  }
}
```

Result:
```
{
  "data": {
    "order": {
      "id": "72d95bfd-1dac-4bc2-adc1-f28fd43777fd",
      "orderEntries": [
        {
          "description": "Bechreibung 1"
        },
        {
          "description": "Bechreibung 2"
        }
      ]
    }
  },
  "extensions": {
    "tracing": {
      "version": 1,
      "startTime": "2021-07-16T08:43:41.9948922Z",
      "endTime": "2021-07-16T08:43:42.0008922Z",
      "duration": 6289900,
      "parsing": {
        "startOffset": 400,
        "duration": 44200
      },
      "validation": {
        "startOffset": 45900,
        "duration": 76199
      },
      "execution": {
        "resolvers": []
      }
    }
  }
}
```