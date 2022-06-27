#!/bin/bash

docker run \
    -e RUN_LOCAL=true \
    -e USE_FIND_ALGORITHM=true \
    -e LOG_LEVEL=WARN \
    -v "$PWD":/tmp/lint \
    github/super-linter
