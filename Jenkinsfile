library 'JenkinsBuilderLibrary'

helper.gitHubUsername = 'jakegough-jaytwo'
helper.gitHubRepository = 'jaytwo.AsyncHelper'
helper.gitHubTokenCredentialsId = 'github-jakegough-jaytwo-token'
helper.nuGetCredentialsId = 'nuget-org-jaytwo'
helper.xunitTestResultsPattern = 'out/testResults/**/*.trx'
helper.coberturaCoverageReport = 'out/coverage/Cobertura.xml';
helper.htmlCoverageReportDir = 'out/coverage/html';

helper.run('linux && make && docker', {
    def timestamp = helper.getTimestamp()
    def safeJobName = helper.getSafeJobName()
    def dockerLocalTag = "jenkins__${safeJobName}__${timestamp}"
    
    withEnv(["DOCKER_TAG=${dockerLocalTag}", "TIMESTAMP=${timestamp}"]) {
        try {
            stage ('Build') {
                sh "make docker-builder"
            }
            docker.image(dockerLocalTag).inside() {
                stage ('Unit Test') {
                    sh "make unit-test"
                }
                stage ('Pack') {
                    if(env.BRANCH_NAME == 'master'){
                        sh "make pack"
                    } else {
                        sh "make pack-beta"
                    }
                }
                if(env.BRANCH_NAME == 'master' || env.BRANCH_NAME == 'develop'){
                    stage ('Publish NuGet') {
                        sh "make nuget-check"
                        // helper.pushNugetPackage('out/packed')
                    }
                }
            }
        }
        finally {
            // inside the withEnv()
            sh "make docker-clean"
        }
    }
})
