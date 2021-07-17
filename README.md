# GraphQL-BFF
This is a training repository to get familiar with GraphQL and check the usefulness of using GraphQL as a BFF (Backend-For-Frontend)

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

### Gateway
- start customer service (Port: 5010)
- start order service (Port: 5020)
- start gateway (Port: 5000)
- use query 

```
{
  customers{
    id
    firstname,
    lastname,
    dayOfBirth
    orders {
      id,
      date,
      orderEntries {
        name,
        description,
        price
      }
    }
  }
}
```
Result:
```
{
  "data": {
    "customers": [
      {
        "id": "00bcd523-dc9b-4d23-95ed-0cf10daace5f",
        "firstname": "Hans",
        "lastname": "Werner",
        "dayOfBirth": "1970-11-04T00:00:00.000+01:00",
        "orders": [
          {
            "id": "72d95bfd-1dac-4bc2-adc1-f28fd43777fd",
            "date": "2021-07-16T22:37:21.333+02:00",
            "orderEntries": [
              {
                "name": "Product 1",
                "description": "Product Description 1",
                "price": 120
              },
              {
                "name": "Product 2",
                "description": "Product Description 2",
                "price": 150
              },
              {
                "name": "Product 3",
                "description": "Product Description 3",
                "price": 165
              }
            ]
          }
        ]
      },
      {
        "id": "8e1c119d-6043-4428-9e17-99beb7964a42",
        "firstname": "Ben",
        "lastname": "Schuster",
        "dayOfBirth": "1973-05-06T00:00:00.000+02:00",
        "orders": []
      },
      {
        "id": "b0b0f29a-8224-48f2-aa9d-a9fcaf634579",
        "firstname": "Alfred",
        "lastname": "Müller",
        "dayOfBirth": "1982-07-12T00:00:00.000+02:00",
        "orders": []
      },
      {
        "id": "883dde2a-c426-4024-9aef-f8a91af366f1",
        "firstname": "Wolfgang",
        "lastname": "Fleischer",
        "dayOfBirth": "1967-07-21T00:00:00.000+02:00",
        "orders": []
      },
      {
        "id": "e39c76be-758c-48d3-84dc-673df528d559",
        "firstname": "Max",
        "lastname": "Mustermann",
        "dayOfBirth": "1949-12-02T00:00:00.000+01:00",
        "orders": []
      }
    ]
  }
}
```
## Getting Started

Make sure you have [installed](https://docs.docker.com/docker-for-windows/install/) docker in your environment. After that, you can run the below commands from the **/src/** directory and get started immediately.

```powershell
docker-compose build
docker-compose up
```

You should be able to browse different components of the application by using the below URLs :

```
Customers API: http://host.docker.internal:5010/ui/altair
Orders API:  http://host.docker.internal:5020/ui/altair
Backend For Frontend:  http://host.docker.internal:5000/ui/altair
```

