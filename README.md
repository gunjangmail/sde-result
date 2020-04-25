# SDE Online Assessment

The purpose of this program is to run as .NET console application or in docker container

- This application is developed in .NET console application, so it's required .NET framework 4.8
- For docker it's derived from Microsoft base image as mcr.microsoft.com/dotnet/framework/runtime:4.8-windowsservercore-ltsc2019
- Output as generated as result.json file.

Development Enhancement  
- We can build this application in .NET core which will give flexibility to run the app on any platform.
- I was not able to use .NET code because of limited development environment and support.

We can run the exec for generating the result.

### Sample input

```json
{
  "data": [
    {
      "id": "c1",
      "type": "corporate",
      "tenor": "10.3 years",
      "yield": "5.30%",
      "amount_outstanding": 1200000
    },
    {
      "id": "g1",
      "type": "government",
      "tenor": "9.4 years",
      "yield": "3.70%",
      "amount_outstanding": 2500000
    },
    {
      "id": "c2",
      "type": "corporate",
      "tenor": "13.5 years",
      "yield": null,
      "amount_outstanding": 1100000
    },
    {
      "id": "g2",
      "type": "government",
      "tenor": "12.0 years",
      "yield": "4.80%",
      "amount_outstanding": 1750000
    }
  ]
}
```

### Sample output result

```json
{
  "data": [
    {
      "corporate_bond_id": "c1",
      "government_bond_id": "g1",
      "spread_to_benchmark": "160 bps"
    }
  ]
}
```

### Explanation


## Submission

Latest code can be find into git https://github.com/overbond/sde-test
