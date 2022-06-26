docker run \
    -e RUN_LOCAL=true \
    -e USE_FIND_ALGORITHM=true \
    -v /src:/tmp/lint \
    github/super-linter
