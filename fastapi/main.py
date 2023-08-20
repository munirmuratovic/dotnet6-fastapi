from typing import Union

from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI()


class Item(BaseModel):
    name: str


@app.post("/")
def post_root(item: Item):
    return {"message": item.name}
