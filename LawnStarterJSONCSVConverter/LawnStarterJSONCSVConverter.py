
import json
import csv

def json_to_csv(json_file, csv_file):
    with open(json_file, "r") as infile:
        data = json.load(infile)

    rows = list(data.values())

    fieldnames = sorted({key for row in rows for key in row.keys()})

    with open(csv_file, "w", newline="", encoding="utf-8") as outfile:
        writer = csv.DictWriter(outfile, fieldnames=["id"] + fieldnames)
        writer.writeheader()
        for row_id, row_data in data.items():
            row_data_with_id = {"id": row_id, **row_data}
            writer.writerow(row_data_with_id)

if __name__ == "__main__":
    json_to_csv("sample.json", "output.csv")
