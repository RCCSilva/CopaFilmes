FROM node:14.13.1-slim

COPY . .
RUN yarn
RUN yarn build
RUN yarn global add serve

ENTRYPOINT ["serve", "-s", "build"]